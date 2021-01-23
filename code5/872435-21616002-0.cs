    foreach (var item in MyList)
    {
    	if (item.GetType().IsGenericType)
    	{
    		Type genericType = item.GetType().GetGenericArguments()[0];
    		...
    	}
    }
