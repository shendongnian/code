    private void DataGridView_CellContentClick(Object sender, DataGridViewCellEventArgs e)
    {
        DataGridView grid = (DataGridView)sender;
        var chkCell = grid[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
        if (chkCell != null)
        {
            bool checked = (bool)chkCell.EditedFormattedValue;
            // ...
        }
    }
