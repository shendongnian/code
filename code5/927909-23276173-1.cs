    public static string ColumnValueOrDefault(this DataRow row, string column, string defaultValue)
    {
     	if (row == null)
    	{
    		throw new ArgumentNullException("row");
    	}
    	
    	if (column == null)
    	{
    		throw new ArgumentNullException("column");
    	}
    	if (defaultValue == null)
    	{
    		throw new ArgumentNullException("defaultValue");
    	}
    	
    	var rowString = row[column].ToString();
    	
        return string.IsNullOrEmpty(rowString) ? defaultValue : rowString;
    }
    Address.State = row.ColumnValueOrDefault("column", Address.State);
