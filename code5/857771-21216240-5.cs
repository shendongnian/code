	var jsonInput = @"d:\temp\json.net\lib{0}.json";
	try
	{
		// load libraries / deserialize json
		var libraries = new List<Library>();
		Enumerable.Range(1, 4).ToList().ForEach(index => 
		{
			var json = File.ReadAllText(String.Format(jsonInput, index));
			libraries.Add(JsonConvert.DeserializeObject<Library>(json));
		});
		// OS names to check if present in the current rules
		var osNames = new List<String> { "osx", "linux" };
		// check each library
		foreach (var library in libraries)
		{
			// do we have rules?
			if (library.Rules.Length > 0)
			{
				// get all non-empty OS nodes
				var existingOsNodes = library.Rules.Where (r => r.Os != null).Select (r => r.Os).ToList();
				// check for allowed OS name
				var osIsPresent = existingOsNodes.Where (node => osNames.Contains(node.Name.ToLower())).Select (node => node.Name);
				if (osIsPresent.Any())
				{
					Console.WriteLine(library.Name);
				}
			}
		}
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
	}
