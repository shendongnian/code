    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        // you can even make it IDbContextProvider with .Current() method in order not
        // to place a hard dependency but depend on Interface which is the proper way.
        // I was in a hurry and did not want to overcomplicate the implementation.
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected IDbSet<T> CreateSet<T>() where T : class
        {
            return _dbContext.Set<T>(); 
        }
        public virtual T Find(int id)
        {
            return CreateSet<T>().Find(id);
        }
    ... 
    }
