    private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        var grid = sender as DataGrid;
        if (grid == null || !grid.SelectedCells.Any())
            return;
        var row = grid.Items.IndexOf(grid.SelectedCells[0].Item);
        try
        {
            // Disable the event handler to prevent a stack overflow.
            grid.SelectedCellsChanged -= DataGrid_SelectedCellsChanged;
            // If any of the selected cells don't match the row of the first selected cell,
            // undo the selection by removing the added cells and adding the removed cells.
            if (grid.SelectedCells.Any(c => grid.Items.IndexOf(c.Item) != row))
            {
                e.AddedCells.ToList().ForEach(c => grid.SelectedCells.Remove(c));
                e.RemovedCells.ToList().ForEach(c => grid.SelectedCells.Add(c));
            }
        }
        finally
        {
            // Don't forget to re-enable the event handler.
            grid.SelectedCellsChanged += DataGrid_SelectedCellsChanged;
        }
    }
