    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.IsCurrentCellDirty)
        {
            var value = ((DataGridView) sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
    }
