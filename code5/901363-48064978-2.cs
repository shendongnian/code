    private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == colRadioButton.Index)
        {
            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)grid.Rows[e.RowIndex].Cells[colRadioButton.Index];
            cell.Value = true;
            radioButtonChanged();
        }
    }
