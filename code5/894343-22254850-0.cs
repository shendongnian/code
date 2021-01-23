    public static IDictionary<string, string> GetEnumBindings<T>()
    {
    	if (!typeof(Enum).IsAssignableFrom(typeof(T)))
    	{
    		throw new ArgumentException("The provided type is not an enum");
    	}
    
    	var result = new Dictionary<string, string>();
    	var fieldNames = Enum.GetNames(typeof (T));
    
    	foreach (var fieldName in fieldNames)
    	{
    		var fieldAttributes = typeof (T).GetField(fieldName)
    									   .GetCustomAttributes(typeof (DescriptionAttribute), false);
    
    		var description = fieldAttributes.Any()
    							  ? ((DescriptionAttribute) fieldAttributes.First()).Description
    							  : fieldName;
    
    		result.Add(description, fieldName);
    	}
    
    	return result;
    }
