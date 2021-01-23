    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keyValues);
        
        // ...
    }
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSet;
        
        public Repository(IDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }
        
        public virtual TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }
        
        // ...
    }
