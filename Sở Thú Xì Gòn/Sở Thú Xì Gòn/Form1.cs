﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sở_Thú_Xì_Gòn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            int index = lb.IndexFromPoint(e.X, e.Y);

            lb.DoDragDrop(lb.Items[index].ToString(),
                            DragDropEffects.Copy);
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.Move;
        }

        private void lstDanhSach_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent (DataFormats.Text))
            {
                ListBox lb = (ListBox)sender;
                lb.Items.Add(e.Data.GetData(DataFormats.Text));
            }
        }

        private void Save(object sender, EventArgs e)
        {
            //Motaptin
            StreamWriter write = new StreamWriter("danhsachthu.txt");

            if (write == null) return;

            foreach (var item in lstDanhSach.Items)
                write.WriteLine(item.ToString());

            write.Close();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuLoad_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("thumoi.txt");
            if (reader == null) return;
            String input = null;
            while ((input= reader.ReadLine()) !=null)
            {
                lstThuMoi.Items.Add(input);
            }
            reader.Close();

            using (StreamReader rs = new StreamReader("danhsachthu.txt"))
            {
                 input = null;
            while ((input= rs.ReadLine()) !=null)
            {
                lstDanhSach.Items.Add(input);
            }
        }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = String.Format("Bây giờ là {0}:{1}:{2} ngày {3} tháng {4} năm {5}",
                                            DateTime.Now.Hour,
                                            DateTime.Now.Minute,
                                            DateTime.Now.Second,
                                            DateTime.Now.Day,
                                            DateTime.Now.Month,
                                            DateTime.Now.Year);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            lstDanhSach.Items.Remove(lstDanhSach.SelectedItem);
        }
    }
}
