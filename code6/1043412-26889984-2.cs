    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	// clear sorting!
    	foreach (DataGridColumn column in this.dgMain.Columns)
    	{
    		column.SortDirection = null;
    	}
    
    	testArray.Add(new ItemModel("A:fourth", "ee"));
    }
