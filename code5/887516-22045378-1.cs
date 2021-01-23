    /// Returns a string that can be used as a C# type definition.
    string GetTypeDefinition(Type t)
    {
        if (t == typeof(void)) return "void";
    	StringBuilder sb = new StringBuilder();
    
    	string name = t.IsGenericType ? t.FullName.Substring(0, t.FullName.IndexOf("`")) : t.FullName;
    
    	sb.Append(name);
    
    	if (t.IsGenericType)
        {
    		sb.Append("<");
    		bool first = true;
    		foreach(Type genericType in t.GenericTypeArguments)
            {
    			if (!first) 
    			{
    				sb.Append(", ");
                }
    			first = false;
    			sb.Append(GetTypeDefinition(genericType));
            }
    		sb.Append(">");
        }
    
    	if (t.IsArray)
        {
    		sb.Append("[]");
        }
    
    	return sb.ToString();
    }
