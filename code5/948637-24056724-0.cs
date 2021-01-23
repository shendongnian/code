	public IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> source)
	{
		if (!source.Any())
		{
			return Enumerable.Empty<IEnumerable<T>>();
		}
		else if (!source.Skip(1).Any())
		{
			return new [] { source, source.Take(0) };
		}
		else
		{
			return Combinations(source.Skip(1))
				.SelectMany(xs => new [] { source.Take(1).Concat(xs), xs });
		}
	}
