    DataGrid dataGrid = sender as DataGrid;
	if (dataGrid == null)
	{
		return; 
	}
	int currentRow = e.Row.GetIndex();
	if (dataGrid.Items.Count - 1 <= currentRow)
	{
		Things.Add(new Thing());
	}
