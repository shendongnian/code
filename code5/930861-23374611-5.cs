    private static void ReplaceDictionaryImpl<TKey, TValue>(IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<object, object>> newContents)
    {
    	dictionary.Clear();
    	foreach (KeyValuePair<object, object> item in newContents)
    	{
    		if (item.Key is TKey)
    		{
    			// if the item was not a T, some conversion failed. the error message will be propagated,
    			// but in the meanwhile we need to make a placeholder element in the dictionary.
    			TKey castKey = (TKey)item.Key; // this cast shouldn't fail
    			TValue castValue = (item.Value is TValue) ? (TValue)item.Value : default(TValue);
    			dictionary[castKey] = castValue;
    		}
    	}
    }
