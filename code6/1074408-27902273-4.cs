    public static class TypeExtensions
    {
    	public static IEnumerable<PropertyInfo> GetAllProperties(this TypeInfo type, 
                                                                 BindingFlags bindingFlags)
    	{
    		var propertyInfos = type.GetProperties(bindingFlags);
    	
    		var subtype = type.BaseType;
    		if (subtype != null)
    			list.AddRange(subtype.GetTypeInfo().GetAllProperties(bindingFlags));
    	
    		return propertyInfos.ToArray();
    	}
    }
