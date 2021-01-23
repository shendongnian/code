	var myDictionary = new Dictionary<string, string>
		{
			{"a", "b"},
			{"f", "v"}
		};
	var anotherDictionary = new Dictionary<string, string>
		{
			{"s", "d"},
			{"r", "m"}
		};
	// Merge anotherDictionary into myDictionary, which may throw
	// (as usually) on duplicate keys
	foreach (var keyValuePair in anotherDictionary)
	{
		myDictionary.Add(keyValuePair.Key, keyValuePair.Value);
	}
