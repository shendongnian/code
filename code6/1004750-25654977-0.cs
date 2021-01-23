	var deserializer = new Deserializer();
	var result = deserializer.Deserialize<List<Hashtable>>(new StringReader(yaml));
	foreach (var item in result)
	{
		Console.WriteLine("Item:");
		foreach (DictionaryEntry entry in item)
		{
			Console.WriteLine("- {0} = {1}", entry.Key, entry.Value);
		}
	}
