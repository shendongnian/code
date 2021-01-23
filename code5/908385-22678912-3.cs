    public class SqlRepository<T>: IRepository<T> where T: class, IEntity
    {
        protected readonly DbSet<T> _objectSet;
        protected ApplicationDbContext _context;
        public SqlRepository(ApplicationDbContext context)
        {
            _objectSet = context.Set<T>();
            this._context = context;
        }
        public void Add(T item)
        {
            _objectSet.Add(item);
        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
       
        public void Remove(T item)
        {
            _objectSet.Remove(item);
        }
        public T First(Expression<Func<T, bool>> predicate, params string[] path)
        {
            IQueryable<T> query = _objectSet;
            if (path != null)
            {
                path.ForeEach(i => query = query.Include(i));
            }
            
            return query.FirstOrDefault(predicate);
        }
        public T First<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] path)
        {
            IQueryable<T> query = _objectSet;
            path.ForeEach(p => query = query.Include(p));
            return query.First(predicate);
        }
        public IQueryable<T> Where<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] path)
        {
            IQueryable<T> query = _objectSet;
            path.ForeEach(p => query = query.Include(p));
            return query.Where(predicate);
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = _objectSet;
            includes.ForeEach(i => query = query.Include(i));
            return query.Where(predicate);
        }
        public IQueryable<T> All<TProperty>(params Expression<Func<T, TProperty>>[] path)
        {
            IQueryable<T> query = _objectSet;
            if (path != null)
            {
                path.ForeEach(p => query.Include(p));
            }
            return query;
        }
        public IQueryable<T> All(params string[] path)
        {
            IQueryable<T> query = _objectSet;
            if (path != null)
            {
                path.ForeEach(p => query = query.Include(p));
            }
            return query;
        }
        public T Find(object id)
        {
            return _objectSet.Find(id);
        }
        public void Attach(T item)
        {
            T old = _objectSet.Local.FirstOrDefault(i => i.Id == item.Id);
            if (old != null)
            {
                _context.Entry<T>(old).State = EntityState.Detached;
            }
            _objectSet.Attach(item);
        }
        public System.Threading.Tasks.Task<T> FirstAsync(Expression<Func<T, bool>> predicate, params string[] path)
        {
            IQueryable<T> query = _objectSet;
            if(path != null)
            {
                path.ForeEach(i => query = query.Include(i));
            }
            return query.FirstOrDefaultAsync(predicate);
        }
    }
