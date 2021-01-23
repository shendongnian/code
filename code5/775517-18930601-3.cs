	public static IEnumerable<T> GetModified<TId, T>
		(IQueryable<T> objects, TId[] ids) where T : class, HasId<TId>
	{
		return objects.Where(j => ids.Contains(j.Id));
	}
