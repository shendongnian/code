    private void DGV_SelectionChanged(object sender, EventArgs e)
    {
        DataGridViewCell cell = DGV.CurrentCell;
        if (cell.ColumnIndex < DGV.ColumnCount - 1)
        {
            DGV.InvalidateCell(cell.ColumnIndex + 1, cell.RowIndex);
            if (cell.RowIndex > 0) 
                DGV.InvalidateCell(cell.ColumnIndex + 1, cell.RowIndex - 1);
            if (cell.RowIndex < DGV.ColumnCount -1)
                DGV.InvalidateCell(cell.ColumnIndex + 1, cell.RowIndex + 1);
        }
    } 
