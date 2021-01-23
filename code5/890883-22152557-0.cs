	public static IEnumerable<T> Fill<T>(this IEnumerable<T> target, int minLength)
	{
		int i = 0;
		
		foreach (var item in target)
		{
			i++;
			yield return item;
		}
		
		while (i < minLength)
		{
			i++;
			yield return default(T);
		}
	}
    
