    public static string IsNullOrEmpty(this DataRow row, string column, string defaultValue)
    {
     	if (row == null)
    	{
    		throw new ArgumentNullException("row");
    	}
    	
    	if (string == null)
    	{
    		throw new ArgumentNullException("column");
    	}
    	
    	var rowString = row[column].ToString();
    	
        return string.IsNullOrEmpty(rowString) ? defaultValue : rowString;
    }
    Address.State = row.IsNullOrEmpty("column", Address.State);
