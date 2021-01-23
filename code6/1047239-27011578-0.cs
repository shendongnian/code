    interface IBaseContext { }
    interface IDatabaseFactory<TContext> : IDisposable
        where TContext : DbContext
    {
        TContext Get();
        void Set(string connectionString);
    }
    interface IEntity { }
    interface IRepository<T> 
        where T : class, IEntity
    { }
        
    abstract class Repository<TContext, T> : IRepository<T>
        where TContext : DbContext, IBaseContext
        where T : class, IEntity
    {
        protected readonly IDbSet<T> dbset;
        private TContext dataContext;
        protected Repository(IDatabaseFactory<TContext> databaseFactory)
        {
            this.DatabaseFactory = databaseFactory;
            this.dbset = DataContext.Set<T>();
        }
        protected IDatabaseFactory<TContext> DatabaseFactory { get; private set; }
        protected TContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        //etc...
    }
