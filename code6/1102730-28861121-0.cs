    public string PKCol;
    
    public void ForceSelect(int IDToFind)
    {
    	if (IDToFind > -1 and DataContext is DataView )
    	{
    		foreach( DataRowView drv in (DataView)DataContext )
    		if ((int)drv[PKCol] == IDToFind)
    		{
    			// This is the data row view record you want...
    			SelectedItem = drv;
    		}
    	}
    }
