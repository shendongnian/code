    public static class MyExtensions
    {
        public static IQueryable<TEntity> Include<TEntity>(
            this IQueryable<TEntity> query, string path)
        {
            var efQuery = query as ObjectQuery<TEntity>;
            if (efQuery == null)
                return query;
            return efQuery.Include(path);
        }
    }
