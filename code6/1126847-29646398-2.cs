	public static Dictionary<string, object> CreateNestedDictionary(string[] chainNodes, string value)
	{
		// Testvalues:
		// ["application", "deepNode", "evenDeeperNode"], "Value"
		var key = chainNodes.First();
		chainNodes = chainNodes.Skip(1).ToArray();
		return new Dictionary<string, object> { { key, chainNodes.Any() ? CreateNestedDictionary(chainNodes, value) : value } };	
	}
