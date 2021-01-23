    public interface IMyAsyncDbSet<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Remove(TEntity entity);
        // Copy other methods from IDbSet<T> as needed.
    
        Task<Object> FindAsync(params Object[] keyValues);
    }
    
    public class MyDbSet<T> : DbSet<T>, IMyAsyncDbSet<T>
        where T : class
    {
    }
