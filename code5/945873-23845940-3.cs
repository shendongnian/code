	try
	{	        
		var xmlFile = "c:\\input.xml";
		// load the xml file
		var xml = XDocument.Load(xmlFile);
		// find all operations nodes
		var operations = xml.Root.Descendants("Operations").ToList();
		// iterate over all nodes
		foreach (var operation in operations)
		{
			// find the operation node with type INTRODUCTION
			var op = operation.Elements().Where (o => o.Name == "Operation" && (o.Attribute("type").Value.ToUpper() == "INTRODUCTION")).FirstOrDefault();
			if (op != null)
			{
				// find the timestamp node
				var timestamp = op.Elements().Where (o => o.Name == "Column" && (o.Attribute("name").Value.ToUpper() == "TIMESTAMP")).FirstOrDefault();
				if (timestamp != null)
				{
					// and get the value
					Console.WriteLine(timestamp.Value);
				}
			}
		}
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
