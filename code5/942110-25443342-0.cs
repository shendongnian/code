    public interface IAsyncDbSet<T> : IDbSet<T>
        where T : class
    {
        Task<T> FindAsync(params Object[] keyValues);
    }
    
    public sealed class DbSetAdapter<T> : IAsyncDbSet<T>, IDbSet<T>
        where T : class
    {
        private readonly DbSet<T> _innerDbSet;
    
        public DbSetAdapter(DbSet<T> innerDbSet)
        {
            _innerDbSet = innerDbSet;
        }
    
       public Task<T> FindAsync(params object[] keyValues)
       {
              return _innerDbSet.FindAsync(keyValues);
       }
       //Here implement each method so they call _innerDbSet like I did for FindAsync
    }
