    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        DataGridViewCell cell = dataGridView1.CurrentCell;
        if (cell.ColumnIndex < dataGridView1.ColumnCount - 1)
        {
            dataGridView1.InvalidateCell(cell.ColumnIndex + 1, cell.RowIndex);
            if (cell.RowIndex > 0) 
                dataGridView1.InvalidateCell(cell.ColumnIndex + 1, cell.RowIndex - 1);
            if (cell.RowIndex < DGV.ColumnCount -1)
                dataGridView1.InvalidateCell(cell.ColumnIndex + 1, cell.RowIndex + 1);
        }
    } 
