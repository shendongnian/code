	foreach (string key in keyIndexCollection.Keys)
	{
		int[] values = keyIndexCollection[key];
		Console.WriteLine("Key = " + key);
		foreach (int value in values)
		{
			Console.WriteLine("\tValue = " + value);
		}
	}
