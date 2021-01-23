    public class QueryEntities<TId> : IQueryEntities<TId>
    {
        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : Entity<TId>
        {
            ...
        }
    }
