    public class DataService
    {
        public readonly ApplicationDbContext dbContext;
        public DataService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create<TEntity>(TEntity entity) where TEntity : IDbDictionary 
        {
            this.dbContext.Set<TEntity>().Add(entity);
            this.dbContext.SaveChanges();
        }
    }
