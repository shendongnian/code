    public static IEnumerable<T> Join<T>(T separator, IEnumerable<IEnumerable<T>> items)
	{
		var sep = new[] {item};
		var first = items.FirstOrDefault();
		if (first == null)
			return Enumerable.Empty<T>();
		else
			return first.Concat(items.Skip(1).SelectMany(i => sep.Concat(i)));		
	}
