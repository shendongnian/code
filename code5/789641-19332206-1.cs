	var input = @"Data={Person, Id, Specification={Id, Destination={Country, Price}}}";
	var content = retrieve(input);
	Console.Out.WriteLine(content);
	if (!string.IsNullOrEmpty(content))
	{
		var subcontent = retrieve(content);
		Console.Out.WriteLine(subcontent);
		// and so on...
	}
