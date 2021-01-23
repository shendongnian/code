    public void PrintProperties(object obj, int indent)
    {
    
        if (obj == null) return;
        string indentString = new string(' ', indent);
        Type objType = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties();
        foreach (PropertyInfo property in properties)
        {	
            object propValue = property.GetValue(obj, null);
    		if(property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
    			Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
    		else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
    		{
    			Console.WriteLine("{0}{1}:", indentString, property.Name);
    			IEnumerable enumerable = (IEnumerable)propValue;
    			foreach(object child in enumerable)
    				PrintProperties(child, indent + 2);
    		}
    		else 
    		{
    			Console.WriteLine("{0}{1}:", indentString, property.Name);
    			PrintProperties(propValue, indent + 2);
    		}
    	}
    }
