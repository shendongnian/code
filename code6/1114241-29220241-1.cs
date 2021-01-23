    public TEntity GetByUserID(Guid userID, params Include<TEntity>[] includes)
	{
		var query = this.DbSet;
		query = Where<IDeletableEntity>(query, x => !x.IsDeleted);
		return query
			.FirstOrDefault(x => x.UserID == userID);
	}
	public static IQueryable<TEntity> Where<TPredicateWellKnownType>(IQueryable<TEntity> query, Expression<Func<TPredicateWellKnownType, bool>> predicate)
	{
		if (typeof(TEntity).IsImplementationOf<TPredicateWellKnownType>())
		{
			query = ((IQueryable<TPredicateWellKnownType>)query)
				.Where(predicate)
				.Cast<TEntity>();
		}
		return query;
	}
