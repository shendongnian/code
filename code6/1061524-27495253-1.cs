	while(reader.Accept<DocumentStart>())
	{
		// Deserialize the document
		var doc = deserializer.Deserialize<List<string>>(reader);
			
		Console.WriteLine("## Document");
		foreach(var item in doc)
		{
			Console.WriteLine(item);
		}
	}
