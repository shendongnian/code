    namespace WindowsFormsApplication1
    {
       using System;
       using System.Windows.Forms;
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
          }
          private void button1_Click(object sender, EventArgs e)
          {
             for (int i = 0; i < 5; i++)
             {
                DateTime dt = DateTime.Now;
                dataGridView1.Columns[0].DataGridView.Rows.Add(dt);
                dataGridView1.Columns[0].DefaultCellStyle.Format = "T";
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.DefaultCellStyle.Format = "HH:mm";
                }
             }
          }
       }
    }
