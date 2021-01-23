    public static IEnumerable<List<T>> SplitBefore<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		return source.Aggregate(
			Enumerable.Repeat(new List<T>(), 1),
			(list, value) =>
			{
				if (predicate(value) && list.Last().Any())
					list = list.Concat(Enumerable.Repeat(new List<T>(), 1));
				list.Last().Add(value);
				return list;
			}
		);
	}
	public static IEnumerable<List<T>> SplitAfter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		return source.Aggregate(
			Enumerable.Repeat(new List<T>(), 1),
			(list, value) =>
			{
				list.Last().Add(value);
				return predicate(value)
					? list.Concat(Enumerable.Repeat(new List<T>(), 1))
					: list;
			}
		);
	}
