	static public void PrintDictionary(Dictionary<string, string> someDictionary)
	{
		foreach(KeyValuePair<string, string> pair in someDictionary)
		{
			Console.Write(pair.Key);
			Console.Write(" => ");
			Console.WriteLine(pair.Value);
		}
	}
	
