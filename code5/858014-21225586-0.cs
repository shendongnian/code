    public T Get<T>(object id)
    {
    	var type = typeof(T);
    	
    	// construct your query based on the type
    	// var queryResult = ...
    	return JsonLibrary.Parse<T>(queryResult);
    }
    var customer = Get<Customer>("ben");
    var vendors = Get<List<Vendor>>("ben&jerrys");
