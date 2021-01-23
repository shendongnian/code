    public static class RepositoryExtensions
    {
        public static TEntity SingleOrDefault<TEntity>(
            this IRepository repository,
            Expression<Func<TEntity, bool>> filter
        )
        {
            return repository.FromStore<TEntity>().SingleOrDefault(filter);
        }
    }
