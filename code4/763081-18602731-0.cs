    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class {
        private DbContext _context;
        public Repository(DbContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }
            _context = context;
        }
        protected DbContext DbContext { get { return _context; } }
        public void Create(TEntity entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }
        public TEntity GetById(int id) {
            return DbContext.Set<TEntity>().Find(id);
        }
        public void Delete(TEntity entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }
        public void Update(TEntity entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
