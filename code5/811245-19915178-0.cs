    public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            Form2 f = new Form2(e.RowIndex, ds.Tables[0]);
            f.Show();
        }
    }
