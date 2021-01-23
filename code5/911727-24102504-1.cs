    public abstract class DbRepository : IDbRepository
    {
        [OperationalContract(Name="Insert")]
        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
        {
           _context.Entry(entity).State = EntityState.Added;
           return entity;
        }
        [OperationalContract(Name="Update")]
        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
           _context.Entry(entity).State = EntityState.Modified;
           return entity;
        }
    }
