    private bool isRowHeaderSelected = false;
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        isRowHeaderSelected = (e.ColumnIndex == -1);
    }
    private void deleteRowButton(object sender, EventArgs e)
    {
        if (isRowHeaderSelected)
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
    }
