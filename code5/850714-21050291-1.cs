    private void DataGrid_BeginningEdit (Object sender, DataGridBeginningEditEventArgs e)
    {
    	DataGrid grid = (DataGrid) sender;
    	Popup pop1 = (Popup) grid.FindName("pop1");
    	pop1.PlacementTarget = grid.GetCell(e.Row.GetIndex(), e.Column.DisplayIndex);
    	pop1.IsOpen = true;
    }
    
    private void DataGrid_CellEditEnding (Object sender, DataGridCellEditEndingEventArgs e)
    {
    	Popup pop1 = (Popup) ((DataGrid) sender).FindName("pop1");
    	pop1.IsOpen = false;
    }
