    interface IUnitOfWork
    {
        int SaveChanges();
    }
    interface IQueryEntities
    {
        IQueryable<T> Query<T>(); // implementation returns Set<T>().AsNoTracking()
        IQueryable<T> EagerLoad<T>(IQueryable<T> queryable, Expression<Func<T, object>> expression); // implementation returns queryable.Include(expression)
    }
    interface ICommandEntities : IQueryEntities, IUnitOfWork
    {
        T Find<T>(params object[] keyValues);
        IQueryable<T> FindMany<T>(); // implementation returns Set<T>() without .AsNoTracking()
        void Create<T>(T entity); // implementation changes Entry(entity).State
        void Update<T>(T entity); // implementation changes Entry(entity).State
        void Delete<T>(T entity); // implementation changes Entry(entity).State
        void Reload<T>(T entity); // implementation invokes Entry(entity).Reload
    }
