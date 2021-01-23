    public interface IRepository<T> : IRepositoryReadOnly<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Save();
    }
