        public void btnSearch_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = dataGridView1.Columns[5].HeaderText.ToString() + " LIKE '%" + txtbxSearch.Text + "%'";
            dataGridView1.DataSource = bs;
        }
