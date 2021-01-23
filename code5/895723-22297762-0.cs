    public interface IRepository<T, in X> : IRepositoryReadOnly<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(X id);
        void Delete(T entity);
        void Save();
    }
