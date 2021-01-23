    public DataTable ConvertListsToDatatable(List<int> list1, List<int> list2)
    {
    	DataTable dt = new DataTable();
    	
    	DataColumn column;
    	DataRow row;
    	
    	// add the first column
    	column = new DataColumn();
    	column.DataType = System.Type.GetType("System.Int32");
    	column.ColumnName = "List1Id";
    	dt.Columns.Add(column);
    	
    	// add the second column
    	column = new DataColumn();
    	column.DataType = System.Type.GetType("System.Int32");
    	column.ColumnName = "List2Id";
    	dt.Columns.Add(column);
    	
    	int i = 0;
    	while ((list1 != null)&&(i < list1.Count) || (list2 != null)&&(i < list2.Count))
    	{
    		row = dt.NewRow();
    		
    		if (list1 != null)
    		{
    			if (i < list1.Count)
    			{
    				row["List1Id"] = List1[i];
    			}
    		}
    		
    		if (list2 != null)
    		{
    			if (i < list2.Count)
    			{
    				row["List2Id"] = List2[i];
    			}
    		}
    		
    		dt.Rows.Add(row);
    		i++;
    	}
    	
    	return dt;
    }
