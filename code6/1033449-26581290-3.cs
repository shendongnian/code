    private void ScrollViewerLoaded( object sender, RoutedEventArgs e )
    {
    	if( grid != null && scrollViewer != null && 
    		grid.ActualHeight > scrollViewer.ActualHeight )
    	{
            if( grid.RowDefinitions.Count < 2 )
            {
                return;
            }
    		// If the Grid is larger than the ScrollViewer, set the
    		// Grids row sizes evenly.
    		var rowDefinitions = grid.RowDefinitions.ToList();
    		for( var i = 0; i < rowDefinitions.Count; i += 2 )
    		{
    			var rowDefinition = rowDefinitions[i];
    			rowDefinition.Height = new GridLength( 200 );
    		}
    	}
    }
    
    private void ScrollViewerElementSizeChanged( object sender, SizeChangedEventArgs e )
    {
        if( grid.RowDefinitions.Count < 2 )
        {
            return;
        }
    	var totalHeight = grid.RowDefinitions.Sum( rd => rd.ActualHeight );
    	if( totalHeight < grid.ActualHeight )
    	{
    		// If the Grids total row heights are less than the height
    		// of the Grid, adjust the last row height so they are equal.
    		var lastRow = grid.RowDefinitions.Last();
    		var otherRowsHeight = totalHeight - lastRow.ActualHeight;
    		var newHeight = grid.ActualHeight - otherRowsHeight;
    		lastRow.Height = new GridLength( newHeight );
    	}
    }
