    private bool TrySetInt32(object value, PropertyInfo propertyInfo, bool isNullable)
    {
    	var done = false;
    	if (value is Int32)
    	{
    		propertyInfo.SetValue(_obj, value);
    		done = true;
    	}
    	else if (value == null)
    	{
    		if (isNullable)
    		{
    			propertyInfo.SetValue(_obj, value);
    			done = true;
    		}
    	}
    	else if (value is Int64) //Json.Net - fallback for numbers is an Int64
    	{
    		var val = (Int64)value;
    		if (val <= Int32.MaxValue && val >= Int32.MinValue)
    		{
    			done = true;
    			propertyInfo.SetValue(_obj, Convert.ToInt32(val));
    		}
    	}
    	else
    	{
    		Int32 val;
    		done = Int32.TryParse(value.ToString(), out val);
    		if (done)
    			propertyInfo.SetValue(_obj, val);
    	}
    	return done;
    }
