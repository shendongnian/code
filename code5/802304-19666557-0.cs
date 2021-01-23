    public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                             Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null,
										 string includeProperties = "")
		{
			IQueryable<TEntity> query = DbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}
