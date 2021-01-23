    public DataTable CopyGenericToDataTable<T>(this IEnumerable<T> items)
    {
    	var properties = typeof(T).GetProperties();
    	var result = new DataTable();
    	
    	//Build the columns
    	foreach ( var prop in properties ) {
    		result.Columns.Add(prop.Name, prop.PropertyType);
    	}
    	
    	//Fill the DataTable
    	foreach( var item in items ){
    		var row = result.NewRow();
    		
    		foreach ( var prop in properties ) {
    			var itemValue = prop.GetValue(item, new object[] {});
    			row[prop.Name] = itemValue;
    		}
    		
    		result.Rows.Add(row);
    	}
    	
    	return result;
    }
