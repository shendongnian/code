    public static class KeyValuePair
    {
    	/// <summary>
    	/// Create a KeyValuePair without having to specify the type arguments. This is similar to Tuple.Create
    	/// </summary>
    	/// <typeparam name="TKey">The type of the key</typeparam>
    	/// <typeparam name="TValue">The type of the value</typeparam>
    	/// <param name="key">Value of the key</param>
    	/// <param name="value">Value of the value</param>
    	/// <returns>KeyValuePair with your specified values</returns>
    	public static KeyValuePair<TKey, TValue> Create<TKey, TValue>(TKey key, TValue value)
    	{
    		return new KeyValuePair<TKey, TValue>(key, value);
    	}
    }
    
    var myList = new List<KeyValuePair<string, int>>
    	{
            //You can use either the extension method or the constructor
            //to initialize the list.  I think the extension method is a bit
            //neater.
            KeyValuePair.Create("key", 1),
            new KeyValuePair<string, int>("keytwo", 2)
    	};
