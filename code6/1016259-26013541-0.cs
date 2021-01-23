    public Interface IUnitOfWork
    {
       void StartTransaction();
       void Commit();
       void Rollback();
       void Save<T>(T entity);
       void Delete<T>(T entity);
    }
    
    public Interface IRepository
    {
       IQueryable<T> Get<T>();
       SingleResult<T> GetSingle<T, TKey>(TKey key);
    }
