    public interface IRepository<T> : IRepositoryReadOnly<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T id);
    void Delete(T entity) where T : <EntityType>;
    void Save();
