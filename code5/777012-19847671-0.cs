	public static T GetById<T>(this IQueryable<T> collection, Guid id)
		where T : class, IEntity
	{
		//...
	}
