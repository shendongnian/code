    var data = new List<string>() { "Key1", "Value1", "Value2", 
                                    "Key2", "Value3", "Value4" };
    string workingKey = null; 
	data.ToLookup(item => {
		if(item.StartsWith("Key"))
		{
			workingKey = item;
			return String.Empty; //use whatever here
		}
		return workingKey;
	}).Where(g => g.Key != String.Empty); //make sure to enumerate this if you plan on setting workingKey after this EDIT: Where is enumerating so no need to enumerate again
