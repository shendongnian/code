    public static IEnumerable<T> Join<T>(T separator, IEnumerable<IEnumerable<T>> items)
	{
		var sep = new[] {separator};
		return items.First().Concat(items.Skip(1).SelectMany(i => sep.Concat(i)));
	}
