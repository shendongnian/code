	foreach(KeyValuePair<string, IDictionary> entryOuter in outerDictionary)
	{
		foreach(KeyValuePair<string, IDictionary> entryMiddle in entryOuter.Value)
		{
			foreach(KeyValuePair<string, string> entry in entryMiddle.Value)
			{
			    // do something with entry.Value
			}
		}
	}
