	private object selectedItem;
	private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
	{
		var dg = (sender as DataGrid);
		if (selectedItem == null)
			selectedItem = e.AddedCells.First().Item;
		var allInSameRow = e.AddedCells.All(info => info.Item == selectedItem);
		if (!allInSameRow)
		{
			dg.SelectedCells.Clear();
			selectedItem = null;
		}
	}
