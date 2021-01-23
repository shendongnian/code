    public IQueryable<TEntity> SelectFirst<TEntity,TKey>(IQueryable<IGrouping<TKey, TEntity>> groupQuery)
        {
        	ParameterExpression param = Expression.Parameter(groupQuery.ElementType, "x");
        	var lambda = Expression.Lambda<Func<IGrouping<TKey, TEntity>,TEntity>>(
        		Expression.Call(typeof(Enumerable),"FirstOrDefault",new []{typeof(TEntity)},param), 
        		param);
        		
        	var select = Expression.Call(
        		typeof(Queryable),
        		"Select",
        		new []{groupQuery.ElementType,typeof(TEntity)},
        		groupQuery.Expression,lambda);
        	return groupQuery.Provider.CreateQuery<TEntity>(select);
        }
