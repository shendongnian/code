    static DataTable ConvertListToDataTable(List<string[]> list)
    	{
    	    // New table.
    	    DataTable table = new DataTable();
    
    	    // Get max columns.
    	    int columns = 0;
    	    foreach (var array in list)
    	    {
    		if (array.Length > columns)
    		{
    		    columns = array.Length;
    		}
    	    }
    
    	    // Add columns.
    	    for (int i = 0; i < columns; i++)
    	    {
    		table.Columns.Add();
    	    }
    
    	    // Add rows.
    	    foreach (var array in list)
    	    {
    		table.Rows.Add(array);
    	    }
    
    	    return table;
    	}
