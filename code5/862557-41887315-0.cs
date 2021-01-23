    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {    
        private readonly DbSet<TEntity> _dbset;
        public Repository(DbSet<TEntity> dbset)
        {
            _dbset = dbset;
        }
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>>[] properties)
        {  
            if (properties == null) 
                throw new ArgumentNullException(nameof(properties));
            var query = _dbset as IQueryable<TEntity>; // _dbSet = dbContext.Set<TEntity>()
            query = properties
                       .Aggregate(query, (current, property) => current.Include(property));
            return query.AsNoTracking().ToList(); //readonly
        }
    }
