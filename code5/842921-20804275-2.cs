    public static class ExtensionMethods
    {
    	public static void PrintDictionary<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
    	{
    		foreach(var kvp in dictionary)
    		{
    			Console.WriteLine("{0}, {1}", kvp.Key, kvp.Value);
    		}
    	}
    }
