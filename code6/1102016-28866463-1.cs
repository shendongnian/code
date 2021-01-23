    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> Includes<TEntity>(this IQueryable<TEntity> queryable, params string[] includeProperties)
        {
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public static IQueryable<TEntity> IncludesWithFunc<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
