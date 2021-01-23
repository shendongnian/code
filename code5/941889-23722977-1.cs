    public interface IGenericRepository<T> where T : class {
        
        IQueryable<T> GetAll();
        IQueryable<T> GetAllAsync();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindByAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
