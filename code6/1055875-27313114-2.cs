	var json = @"
	[{
	""name"":""Wheel"",
	""amount"":4
	},{
	""name"":""Break"",
	""delay"":1.0
	}]";
	// get a list of possible types from the assembly containing Module.
	// don't know of a better way of doing this. 
	var types = typeof (Module).Assembly.GetTypes();
	// parse the original JSON into an array. 
	var joList = JArray.Parse(json);
	// list I want to populate
	var listModule = new List<Module>();
	foreach (dynamic token in joList)
	{
		string name = token.name;
		// get the actual type. 
		var type = types.FirstOrDefault(x=>x.Name == name);
		// if type is not found then continue. 
		if (type == null)
			continue;
		// if type is not a subclass of Module, continue. 
		if (!type.IsSubclassOf(typeof(Module)))
			continue;
		// now deserialize that token into the actual type and add it to the list 
		listModule.Add(JsonConvert.DeserializeObject(token.ToString(), type)); 
	}
