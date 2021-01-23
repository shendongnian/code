    public static bool TryToInt32(object value, out int result)
    {
    	if (value == null)
    	{
    		result = 0;
    		return false;
    	}
    	var typeConverter =  System.ComponentModel.TypeDescriptor.GetConverter(value);
    	if (typeConverter != null && typeConverter.CanConvertTo(typeof(int)))
    	{
    		var convertTo = typeConverter.ConvertTo(value, typeof(int));
    		if (convertTo != null)
    		{
    			result = (int)convertTo;
    			return true;
    		}
    	}
    	return int.TryParse(value.ToString(), out result);
    }
