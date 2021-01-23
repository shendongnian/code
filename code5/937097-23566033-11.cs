    static class DictionaryExtensions
    {
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> target, IDictionary<TKey, TValue> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (target == null) throw new ArgumentNullException("target");
            foreach (var keyValuePair in source)
            {
                target.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
	var myDictionary = new Dictionary<string, string>
		{
			{"a", "b"},
			{"f", "v"}
		};
	myDictionary.Add(new Dictionary<string, string>
		{
			{"s", "d"},
			{"r", "m"}
		});
