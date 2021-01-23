    for (int i = 0; i < existingData.Columns.Count; i++)
    {
    	DataColumn src = existingData.Columns[i];
    
    	DataColumn dest = (gridData.Columns.Contains(src.ColumnName)) ? gridData.Columns[src.ColumnName] : null;
    	if (dest == null)
    	{
    		 //You will get the column here
    	}
    
    	BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
    	MethodInfo minfo = typeof(DataColumnCollection).GetMethod("Contains", bindingFlags); //This override is used internally duting Merge
    
    	var result = minfo.Invoke(gridData.Columns, new object[]{src.ColumnName, true});
    	dest = ((bool)result) ? gridData.Columns[src.ColumnName] : null;                            
    
    	if (dest == null)
    	{
    		//You wont get the column here. Its case sensitive                             
    	}
    }
