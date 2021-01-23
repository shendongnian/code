    private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("items.xml");
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = ds.Tables[0];           
        }
