    foreach (var propInfo in foobar.GetType().GetProperties())
    {
    	var val = propInfo.GetValue(foobar, null);
    
    	if (typeof(IEnumerable).IsAssignableFrom(propInfo.PropertyType))
    	{
    		var collectionItems = (IEnumerable)val;
    		if (collectionItems != null)
    		{
    			foreach (object lval in collectionItems)
    			{
    				Console.WriteLine(lval);
    			}
    		}
    	}
    }
