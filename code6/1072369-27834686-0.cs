	public Type DeepSearchType(string name)
	{
		if(string.IsNullOrWhiteSpace(name))
		   return null;
		
		foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
		{
			foreach (Type t in a.GetTypes())
			{
				if(t.Name.ToUpper().Contains(name.ToUpper()))
				   return t;
			}
		}
		
		return null;
	}
    public List<string> GetEnumValues(string enumName)
    {
    	List<string> result = null;
    	
    	var enumType = Type.GetType(enumName);
    	
        if(enumType == null)
           enumType = DeepSearchType(enumName);
    	if(enumType != null)
    	{
    		result = new List<string>();
    		
    		var enumValues = Enum.GetValues(enumType);
    		
    		foreach(var val in enumValues)
    			result.Add(val.ToString());
    	}
    	
    	return result;
    }
