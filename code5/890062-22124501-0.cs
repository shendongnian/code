    for (int _col = 1; _col < 10; _col++)
    {
    
    	ColumnDefinition coldef = new ColumnDefinition();
    	if (_col == 4 || _col == 7)
    		coldef.Width = new GridLength(35);
    	else
    		coldef.Width = new GridLength(30);
    	grdMain.ColumnDefinitions.Add(coldef);
    }
    for (int _row = 1; _row < 10; _row++)
    {
    	RowDefinition rowDef = new RowDefinition();
    	if ((_row == 4) || (_row == 7))
    	{
    		rowDef.Height = new GridLength(35);
    	}
    	else
    	{
    		rowDef.Height = new GridLength(30);
    	}
    	grdMain.RowDefinitions.Add(rowDef);
    
    	for (int _col = 1; _col < 10; _col++)
    	{
    		TextBox tb = new TextBox();
    		tb.Name = "txt" + _row.ToString() + _col.ToString();
    		tb.MaxLength = 2;
    		tb.Text = _row.ToString() + _col.ToString();
    		tb.Width = 30;
    		tb.Height = 30;
    
    		grdMain.Children.Add(tb);
    
    		Grid.SetRowSpan(tb, 1);
    		Grid.SetColumnSpan(tb, 1);
    
    		Grid.SetRow(tb, _row-1);
    		Grid.SetColumn(tb, _col-1);
    	}
    }
