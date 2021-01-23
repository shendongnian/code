    public static object ConvertList(List<object> items, Type type, bool performConversion = false)
    {
    	var containedType = type.GenericTypeArguments.First();
    	var enumerableType = typeof(System.Linq.Enumerable);
    	var castMethod = enumerableType.GetMethod("Cast").MakeGenericMethod(containedType);
    	var toListMethod = enumerableType.GetMethod("ToList").MakeGenericMethod(containedType);
    	
    	IEnumerable<object> itemsToCast;
    	
    	if(performConversion)
    	{
    		itemsToCast = items.Select(item => Convert.ChangeType(item, containedType));
    	}
    	else 
    	{
    		itemsToCast = items;
    	}
    
    	var castedItems = castMethod.Invoke(null, new[] { itemsToCast });
    
    	return toListMethod.Invoke(null, new[] { castedItems });
    }
