            private void button1_Click(object sender, EventArgs e)
            {
               SearchData();
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                 SearchData();
            }
            private void SearchData()
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = "id like '%" + textBox1.Text + "%'";
                dataGridView1.DataSource = bs;
             }
