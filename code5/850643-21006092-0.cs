	public static Dictionary<K,V> ToDictionaryDbg<T,K,V>(this IEnumerable<T> source, Func<T,K> key, Func<T,V> value)
	{
		if (source == null) return null;
		Dictionary<K, V> result = new Dictionary<K, V>();
		foreach (var element in source)
		{
			K k = default(K);
			V v = default(V);
			try
			{
				k = key(element);
				v = value(element);
				result.Add(k, v);
			}
			catch (ArgumentException aex)
			{
				throw new ArgumentException("Could not add element with key " + k + ". See inner exception.", aex);
			}
		}
		return result;
	}
