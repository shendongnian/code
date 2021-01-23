	public static IEnumerable<T> GetModified<TId, T>
		(IQueryable<T> objects, TId[] ids) where T : class, T : HasId<TId>
	{
		return objects.Where(j => ids.Contains(j.Id));
	}
