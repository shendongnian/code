    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly DbContext _context;
        public DatabaseFactory(DbContext context)
        {
            _context = context;
        }
        
        public T Set<T>() where T : Entity
        {
            return _context.Set<T>();
        }
     }
