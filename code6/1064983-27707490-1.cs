    /// <summary>
    /// MouseMove event handler
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void grid_MouseMove(object sender, MouseEventArgs e)
	{
        // Get the grid that is the source of drag
		Grid selectedGrid = sender as Grid;
		if (selectedGrid != null && e.LeftButton == MouseButtonState.Pressed)
		{
            // Add that grid as drag source and data
			DragDrop.DoDragDrop(selectedGrid, selectedGrid, DragDropEffects.Move);
		}
	}
