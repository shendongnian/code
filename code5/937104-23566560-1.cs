    public static class DictionaryExtensions{
    public static Dictionary<TKey,TValue> AddRange<TKey,TValue>(this IDictionary<TKey,TValue> source,params  KeyValuePair<TKey,TValue>[] items){
    	foreach (var keyValuePair in items)
    	{
        	source.Add(keyValuePair.Key, keyValuePair.Value);
    	}
    	return source;
    	}
    }
