    public static void RemoveWhere<T>(this IList<T> source, Func<T, bool> predicate)
		{
			for (int i = 0; i < source.Count; i++)
			{
				if (predicate(source[i]))
				{
					source.Remove(source[i]);
					i--;
				}
			}
		}
