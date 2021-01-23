    public static bool CompareObjects(object original, object altered)
    {
    	bool result = true;
    
    	//Get the class
    	Type o = original.GetType();
    	Type a = altered.GetType();
    
    	//Cycle through the properties.
    	foreach (PropertyInfo p in o.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    	{
    		Console.WriteLine("Original: {0} = {1}", p.Name, p.GetValue(original, null));
    		Console.WriteLine("Altered: {0} = {1}", p.Name, p.GetValue(altered, null));
    
    		if (!p.PropertyType.IsGenericType)
    		{
    			if (p.GetValue(original, null) != null && p.GetValue(altered, null) != null)
    			{
    				if (!p.GetValue(original, null).ToString().Equals(p.GetValue(altered, null).ToString()))
    				{
    					result = false;
    					break;
    				}
    			}
    			else
    			{
    				//If one is null, the other is not
    				if ((p.GetValue(original, null) == null && p.GetValue(altered, null) != null) || (p.GetValue(original, null) != null && p.GetValue(altered, null) == null))
    				{
    					result = false;
    					break;
    				}
    			}
    		}
    	}
    
    	return result;
    }
    
    public static bool CompareLists<T>(this List<T> original, List<T> altered)
    {
    	bool result = true;
    
    	if (original.Count != altered.Count)
    	{
    		return false;
    	}
    	else
    	{
    		if (original != null && altered != null)
    		{
    			foreach (T item in original)
    			{
    				T object1 = item;
    				T object2 = altered.ElementAt(original.IndexOf(item));
    
    				Type objectType = typeof(T);
    
    				if ((object1 == null && object2 != null) || (object1 != null && object2 == null))
    				{
    					result = false;
    					break;
    				}
    
    				if (!CompareObjects(object1, object2))
    				{
    					result = false;
    					break;
    				}
    			}
    		}
    		else
    		{
    			if ((original == null && altered != null) || (original != null && altered == null))
    			{
    				return false;
    			}
    		}
    	}
    
    	return result;
    }
