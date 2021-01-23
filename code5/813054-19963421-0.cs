    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 5)
            textBox1.Text = dataGridView1.Rows.Cast<DataGridViewRow>()
                                         .Sum(x => Convert.ToDecimal(x.Cells["Column1"].Value))
                                         .ToString();
    }
