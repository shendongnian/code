    private void textBox6_TextChanged(object sender, EventArgs e)
               {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "EmployeeName like 'N" + textBox6.Text + "%'";
                dataGridView1.DataSource = bs;
               }
