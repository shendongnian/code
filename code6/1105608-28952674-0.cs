    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void SaveChanges();
        ...
    }
