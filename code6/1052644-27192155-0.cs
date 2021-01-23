    private static IEnumerable<object> CreateAListContainingOneObject<T>()
    {
    	var listType = typeof(List<>).MakeGenericType(typeof(T));
    	var generic = Activator.CreateInstance(listType);
    	var dynamicList = generic as dynamic;
    
        var instance = new MySpecialType();
    	
    	var instance2 = (T)Activator.CreateInstance(typeof(T));
    
    	var typecheck = instance.GetType() == instance2.GetType();
    	
    	dynamicList.Add(instance);
    	dynamicList.Add(instance2);
    	return dynamicList;
    }
