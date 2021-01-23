    foreach (PropertyInfo propInfo in theType.GetProperties())
    {
    	for (int i = 0; i < reader.FieldCount; i++)
    	{
    		if (reader.GetName(i).Trim().ToLower() == propInfo.Name.Trim().ToLower())
    		{
    			object asObj = reader.GetValue(i);
    			if (asObj is System.DBNull) propInfo.SetValue(thisRow, null, null);
    			else propInfo.SetValue(thisRow, reader.GetValue(i), null);
    		}
    	}
    }
