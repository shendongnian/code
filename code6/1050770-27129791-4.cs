	protected List<TEntity> GetData<TEntity>(Func<IEnumerable<TEntity>,
											 IEnumerable<TEntity>> query) where TEntity : class
	{
		if (!HasQueryExecuted(query))
		{  
			AddQueryToExecutedList(query); 
			return query(_context.Set<TEntity>()).ToList();
		}
		return query(_context.Set<TEntity>().Local).ToList();
	}
