    public interface IMyGenericRepository
    {
       TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
       IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
    }
    public sealed class MyGenericRepository : IMyGenericRepository
    {
        private DbContext _dbContext;
        public virtual TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }
        public virtual IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return DbSet<TEntity>().Where(predicate).AsQueryable<TEntity>();
        }
    }
