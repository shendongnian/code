	public static bool ContainsDuplicates<T>(this IEnumerable<T> items)
	{
		return ContainsDuplicates(items, EqualityComparer<T>.Default);
	}
	public static bool ContainsDuplicates<T>(this IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
	{
		var set = new HashSet<T>(equalityComparer);
		
		foreach (var item in items)
		{
			if (!set.Add(item))
				return true;
		}
		
		return false;
	}
	
