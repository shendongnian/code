    public abstract class Repository<T> : IRepository<T> 
                                         where T : class, IEntity
    {
        protected readonly IDbSet<T> dbset;
        protected Repository(IDatabaseFactory databaseFactory)
        {
            this.dbset = databaseFactory.Set<T>();
        }
        // other code
    }
