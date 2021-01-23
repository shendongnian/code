    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 5)
        {
            decimal result;
            if (!Decimal.TryParse(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), out result))
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            textBox1.Text = dataGridView1.Rows.Cast<DataGridViewRow>()
                                         .Sum(x => Convert.ToDecimal(x.Cells[5].Value))
                                         .ToString();
        }
    }
