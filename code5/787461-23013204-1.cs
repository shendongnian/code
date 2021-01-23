    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity, new()
    {        
    
        protected IDbConnectionFactory dbFactory { get; set; }
    
        public Repository( IDbConnectionFactory factory )
        {
            dbFactory = factory;
        }
    }
