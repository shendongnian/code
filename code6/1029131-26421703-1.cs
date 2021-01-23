    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
    
        public Repository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }
    
       public IQueryable<TEntity> GetAll()
       {
            return _context.Set<TEntity>();
       }
    
       public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
       {
            IQueryable<TEntity> queryable = GetAll();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
       }
    public TEntity Find(params object[] keys)
       {
            return _context.Set<TEntity>().Find(keys);
       }
    ... etc. 
    }
