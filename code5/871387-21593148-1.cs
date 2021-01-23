    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
        {
            Process.Start(this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
        }
    }
