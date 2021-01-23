    public abstract class Entity<TEntity> where TEntity : Entity<TEntity>
    {
        protected DbContext _dbContext;
        protected Entity()
        {
            this._dbContext = new SMTDBContext();
        }
        public void Add()
        {
            this._dbContext.Set<TEntity>().Add((TEntity)this);
            this._dbContext.SaveChanges();
        }
    }
