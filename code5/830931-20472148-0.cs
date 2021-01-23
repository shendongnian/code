    public interface IRepository<T>
        {
            T FindSingle(Expression<Func<T, Boolean>> predicate, params Expression<Func<T, object>>[] includeExpressions);
            void ProxyGenerationOn();
            void ProxyGenerationOff();
            void Detach(T entity);
            void Add(T newEntity);
            void Modify(T entity);
            void Attach(T entity);
            void Remove(T entity);
            void SetCurrentValues(T modifiedEntity, T origEntity);
            T GetById(int id);
            T GetById(int id, bool sealOverride);
            IQueryable<T> GetAll();
            IQueryable<T> GetAll(bool sealOverride);
            IQueryable<T> GetAll(string[] EagerLoadPaths);
            IQueryable<T> Find(Expression<Func<T, Boolean>> predicate);
        }
 
    public interface IUnitOfWork : IDisposable
        {
           //repository implementations go here
           bool SaveChanges()
         }
