    public class BaseDataRepository<T> : IDataRepository, IDisposable where T:class
    {
        public IQueryable<T> GetItems()
        {
            return _context.Set<T>();
        }
    }
