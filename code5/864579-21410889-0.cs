    public static class Extensions
    {
    	public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, List<TValue>> dictionary, TKey key, TValue value)
    	{
    		if (dictionary.ContainsKey(key))
    		{
    			dictionary[key].Add(value);
    		}
    		else
    		{
    			dictionary.Add(key, new List<TValue>{value});
    		}
    	}
    }
