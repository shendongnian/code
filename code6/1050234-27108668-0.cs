	public static TEnum GetEnumByDescription<TEnum>(string desc) where TEnum : struct
	{
	    if(string.IsNullOrEmpty(desc))
	    {
	    	return default(TEnum);
	    }
	    foreach(var field in typeof(TEnum).GetFields(BindingFlags.Static | BindingFlags.Public))
	    {
	    	var attr = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
	    	if(attr != null && attr.Description == desc)
	    	{
	    		return (TEnum)field.GetValue(null);
	    	}
	    }
	    return default(TEnum);
	}
