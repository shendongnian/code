	try
	{
		var result = new List<DataObject>();
		// helper function to fetch node value regarding attribute name
		Func<List<XElement>, String, String> getValueFromAttribute = (list, attributeName) => 
		{
			var r = list.FirstOrDefault(i => i.Attribute("k").Value.ToLower() == attributeName.ToLower());
			return r != null ? r.Value : String.Empty;
		};
		
		var xml = XDocument.Load("d:\\temp\\input.xml");
		// fetch all DATA nodes and iterate over every one
		xml.Root.Descendants("data").ToList().ForEach(data =>
		{
			// fetch INPUT nodes
			var inputs = data.Descendants("input").ToList();
			result.Add(new DataObject
			{
				IP = getValueFromAttribute(inputs, "ipaddress"),
				Name = getValueFromAttribute(inputs, "name"),
				RawData = getValueFromAttribute(inputs, "rawdata")
			});
		});
		result.ForEach(item =>
		{
			Console.WriteLine("{0} - {1} - {2}", item.IP, item.Name, item.RawData);
		});
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
