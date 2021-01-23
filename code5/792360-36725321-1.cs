    public DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
    {
    
    	DataView dv = new DataView(i_dSourceTable);
    
    	//getting distinct values for group column
    	DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn });
    
    	//adding column for the row count
    	dtGroup.Columns.Add("Count", typeof(int));
    
    	//looping thru distinct values for the group, counting
    	foreach (DataRow dr in dtGroup.Rows) {
    		dr["Count"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
    	}
    
    	//returning grouped/counted result
    	return dtGroup;
    }
