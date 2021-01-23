    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        //...
        public  IQueryable<TEntity> IncludesWithFunc<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet;
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
      
    }
