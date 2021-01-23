        internal BackendContainer context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(BackendContainer context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public GenericRepository()
            : this(new BackendContainer())
        {
        }
        public virtual IQueryable<TEntity> All()
        {
            return dbSet.AsQueryable();
        }
