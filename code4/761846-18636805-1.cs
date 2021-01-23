     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
    using System.Linq;
    using System.Text;
     using System.Windows.Forms;
     namespace grid_example
    {
    public partial class Form1 : Form
    {
        DataGridView dgv = new DataGridView();
        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;
            dgv.AllowUserToAddRows = false;
            //dgv.RowHeadersVisible = false;
            define_gridview_columns();
            add_rows();
            
            
        }
        public void define_gridview_columns()
        {
            DataGridViewTextBoxColumn tbox1 = new DataGridViewTextBoxColumn();
            tbox1.HeaderText = "Track Postion";
            tbox1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewTextBoxColumn tbox2 = new DataGridViewTextBoxColumn();
            tbox2.HeaderText = "Tube Sample Content";
            tbox2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewComboBoxColumn cbox1 = new DataGridViewComboBoxColumn();
            cbox1.HeaderText = "Sample Media";
            cbox1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewComboBoxColumn cbox2 = new DataGridViewComboBoxColumn(); ;
            cbox2.HeaderText = "Sample Test";
            cbox2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns.Add(tbox1);
            dgv.Columns.Add(tbox2);
            dgv.Columns.Add(cbox1);
            dgv.Columns.Add(cbox2);
        }
        public void  add_rows()
        {
           
            for (int i = 0; i < 10; i++)
            { 
                dgv.Rows.Add();
            }
        }
    }
