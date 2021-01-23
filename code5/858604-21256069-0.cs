        public abstract class EntityRepositoryBase<TEntity> : IDisposable, IEntityRepositoryBase<TEntity> where TEntity : class , IEntityWithId
        {
            protected EntityRepositoryBase()
            {
                Context = new SomeEntities();
            } 
    
            public abstract ObjectSet<TEntity> EntityCollection { get; }
            public SomeEntities Context { get; set; }
    
            public TEntity GetById(int id)
            {
                return EntityCollection
                    .FirstOrDefault(x => x.Id == id);
            }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
