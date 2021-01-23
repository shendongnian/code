		public virtual IQueryable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> Query = DbSet;
			if (filter != null)
			{
				Query = Query.Where(filter);
			}
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (string IncludeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
				{
					Query = Query.Include(IncludeProperty);
				}
			}
			if (orderBy != null)
			{
				return orderBy(Query);
			}
			return Query;
		}
