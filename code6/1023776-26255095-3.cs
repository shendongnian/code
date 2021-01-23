    public interface IRepository<TEntity>
        where TEntity : class
    {
    }
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DbContext dbContext;
        private DbSet<TEntity> dbSet;
        public IQueryable<TEntity> All
        {
            get
            {
                return dbSet;
            }
        }
        public void InsertOrUpdate(TEntity entity)
        {
        }
    }
    public class Repository<T> : RepositoryBase<T>
        where T : class
    {
        public Repository(DbContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }
    }
