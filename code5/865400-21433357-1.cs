    NameValueCollection collection = new NameValueCollection();
    collection.Add("test", "1");
    collection.Add("test", "2");
    collection.Add("test", "3");
	
    // Produces a comma-separated string of "1,2,3" but you could use any 
    // separator you required
    var result = collection.GetValues("test").ToValueSeparatedString(",");
