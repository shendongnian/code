    public class BaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> dbSet;
        protected readonly DbContext dbContext;
        public BaseRepository() { }
        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }
        // read, update, delete methods here that all use the same dbContext instance
        public int Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            return dbContext.SaveChanges();
        }
        public IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> filter)
        {
            return dbContext.Table<TEntity>().Where(filter); //Not sure what the generic method is to get a table in EF, but it's something like this
        }
    }
