		//Setup Sample Data
		var data1 = new Dictionary<string, string>();
		data1.Add("KeyA", "ValueA");
		data1.Add("KeyB", "ValueB");
		data1.Add("KeyC", "ValueC");
	
		var data2 = new Dictionary<string, string>();
		data2.Add("KeyB", "ValueB");
		data2.Add("KeyC", "ValueC");
		data2.Add("KeyD", "ValueD");
		
		
		//Second DataType in the Dictionary could be something other than a Tuple
		var result = new Dictionary<string, Tuple<string, string>>();
	
		//Fill in for items existing only in data1 and in both data1 and data2
		foreach(var item in data1)
		{
            result.Add(item.Key, new Tuple<string, string>(item.Value, data2.FirstOrDefault(x => x.Key == item.Key).Value));
		}
		//Fill in remaining items that exist only in data2
    	foreach(var item in data2.Where(d2 => !result.Any(x => x.Key == d2.Key )))
    	{
        	result.Add(item.Key, new Tuple<string, string>(null, item.Value));
    	}
	
		//Demonstrating how to access the data
		var formattedOutput = result.Select(x => string.Format("{0}, {1} (of D1), {2} (of D2)", x.Key, x.Value.Item1 ?? "NoValue", x.Value.Item2 ?? "NoValue"));
	
		foreach(var line in formattedOutput)
		{
			Console.WriteLine(line);
		}
