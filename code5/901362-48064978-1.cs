    private void radioButtonChanged()
    {
        if (grid.CurrentCell.ColumnIndex == colRadioButton.Index)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                // Make sure not to uncheck the radio button the user just clicked.
                if (row.Index != grid.CurrentCell.RowIndex)
                {
                    row.Cells[colRadioButton.Index].Value = false;
                }
            }
        }
    }
    
    private void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        radioButtonChanged();
    }
