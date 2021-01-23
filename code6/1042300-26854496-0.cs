    private void DGV_KeyDown(object sender, KeyEventArgs e)
    {
        if( e.KeyCode == Keys.Space && DGV.CurrentCell.ColumnIndex == yourCheckBoxColumn)
        {
            foreach (DataGridViewCell cell in DGV.SelectedCells)
                if (cell.ColumnIndex == yourCheckBoxColumn)     
                                        cell.Value = !((bool)cell.FormattedValue);
        }
    }
