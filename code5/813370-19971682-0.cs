Form1.cs
            private void button1_Click(object sender, EventArgs e)
            {
                  Form2 f = new Form2();
                  f.DataGridCell += new Action<string>(f_DatagridCell);
                  f.ShowDialog();
            }
           void f_DatagridCell(string obj)
           {
             textBox1.Text = obj;
           }
