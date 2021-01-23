    var dictionary = new Dictionary<String, Object>();
    
    dictionary.Add("myKey", new Object());
    
    var myKey = "myKey";
    Object con;
    if (dictionary.ContainsKey(myKey))
    {
    	con = dictionary[myKey];
        // con is populated
    }
    
    // or you can reach dictionary again.
    if (dictionary.TryGetValue(myKey, out con))
    {
    	// con is populated again
    }
