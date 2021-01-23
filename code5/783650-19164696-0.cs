    //Convert
    try
    {
    	var type = typeof(T);
    	if(type == typeof(bool))
    	{
    		bool boolValue;
    		if(bool.TryParse(KeyValue, out boolValue))
    			return boolValue;
    		else
    		{
    			int intValue;
    			if(int.TryParse(KeyValue, out intValue))
    				return System.Convert.ChangeType(intValue, type);
    		}
    	}
    	else
    	{
    		return (T)System.Convert.ChangeType(KeyValue, type);
    	}
    }
    catch
    {
    	return DefaultValue;
    }
