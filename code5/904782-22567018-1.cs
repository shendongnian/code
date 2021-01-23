	public static class DictionaryExtensions
	{
		public static IDictionary<U, T> Reverse<T, U>(this IDictionary<T, U> dictionary)
		{
			var result = new Dictionary<U, T>();
			foreach(var x in dictionary)
			{
				result[x.Value] = x.Key;
			}
			
			return result;
		}
	}
