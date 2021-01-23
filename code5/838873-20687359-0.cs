    // Generic Repository
    public class Repository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        public Repository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }
    
        public IEnumerable<T> Where(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }
    
        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }
    
        // other methods
    }
    
    // Unit of Work interface
    public interface IUnitOfWork
    {
        Repository<Product> ProductsRepository { get; }
    }
    
    // Unit of Work implementation
    public class MyContext : DbContext, IUnitOfWork
    {
        private readonly Repository<Product> _products = null;
    
        public DbSet<Product> Products { get; set; }
    
        public MyContext()
            : base("MyContext")
        {
            _products = new Repository<Product>();
        }
        
        public Repository<Product> ProductsRepository
        {
    	    get { return _products; }
        }
    }
