     public class Repository<T>:IRepository<T> where T:class
        {
            private DbContext context = null;
            private DbSet<T> dbSet = null;
    
            public Repository(DbContext context)
            {
                this.context = context;
                this.dbSet = context.Set<T>();
            }
    
            #region IRepository
    
            public void Insert(T entity)
            {
                dbSet.Add(entity);
            }
    
            public IQueryable<T> GetAll()
            {
                return dbSet;
            }
    
            public void Update(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
    
                this.context.SaveChanges();
            }
    
           #endregion
        }
