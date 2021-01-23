	public static TEntity MaxBy<TEntity, TKey>(
            this IEnumerable<TEntity> source, 
            Func<TEntity, TKey> selector)
	{
		if (source == null || !source.Any())
			return null;
		return source.OrderByDescending(selector)
					.FirstOrDefault();
	} 
