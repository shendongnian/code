    abstract class BaseRepo<TEntity>
    {
        // If you're using Entity Framework, this method could 
        // be implemented here instead.
        protected abstract IQueryable<TEntity> Entities { get; }
        protected IList<TReturn> GetAllPaged<TResult, TKey, TGroup, TReturn>(
            List<Expression<Func<TEntity, bool>>> predicates,
            Expression<Func<TEntity, TResult>> firstSelector,
            Expression<Func<TResult, TKey>> orderSelector,
            Func<TResult, TGroup> groupSelector,
            Func<IGrouping<TGroup, TResult>, TReturn> selector)
        {
            return predicates
                .Aggregate(Entities, (current, predicate) => current.Where(predicate))
                .Select(firstSelector)
                .OrderBy(orderSelector)
                .GroupBy(groupSelector)
                .Select(selector)
                .ToList();
        }
    }
