	var allObjects = new List<Test>();
	var output = new List<List<string>>();
	
    //Get all the properties off the type
	var properties = typeof(Test).GetProperties();
	
    //Maybe you want to order the properties by name?
	foreach (var property in properties) 
	{
        //Get the value for each, against each object
		output.Add(allObjects.Select(o => property.GetValue(o) as string).ToList());
	}
