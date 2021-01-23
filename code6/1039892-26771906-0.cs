    public class DAL
    {
        // .... previously written code
        public DbSet<T> Find<T>(int id) where T : class
        {
            return _context.Set<T>();
        }
    }
