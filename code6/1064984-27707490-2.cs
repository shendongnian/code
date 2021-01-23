    /// <summary>
	/// Drop event handler
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void box_Drop(object sender, DragEventArgs e)
	{
        // Get the selected box in which the object is being dropped
		Grid selectedBox = sender as Grid;
		if (selectedBox != null)
		{
			// Get that data that is being dropped - in this case, the grid from other box
			Grid droppedGrid = (Grid)e.Data.GetData(typeof(Grid));
			// We need to remove the dragged grid from it's source box in order to be able to add it to selected box
			Grid sourceBox = (Grid)droppedGrid.Parent;
			// Remove the dropped grid from source box
			sourceBox.Children.Remove(droppedGrid);
			// We need to remove the other grid from the selected box in order to be able to move it to source box
			// Get existing child element, the box has only one child - the grid that we need
			Grid existingChild = (Grid)selectedBox.Children[0];
			// Remove existing child grid from selected box
			selectedBox.Children.Remove(existingChild);
				
            // Finally, move grids to new boxes
            // Move existing child grid to source box
			sourceBox.Children.Add(existingChild);
			// Move the dropped grid to selected box
			selectedBox.Children.Add(droppedGrid);			
        }
	}
