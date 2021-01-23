    public class QueryBuilder<T> : IQueryBuilder<T>
    {
        DBContext applicationDbContext;
        private IQueryable<T> query;
        public QueryBuilder(DBContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IQueryBuilder<T> Where(Expression<Func<T, bool>> predicate)
        {
            this.query = this.query.Where(predicate);
            return this;
        }
        public IQueryBuilder<T> Include(Expression<Func<T, object>> path)
        {
            this.query = this.query.Include(path);
            return this;
        }
        public IQueryBuilder<T> OrderBy(Expression<Func<T, object>> path)
        {
            this.query = this.query.OrderBy(path);
            return this;
        }
        public IQueryBuilder<T> OrderByDescending(Expression<Func<T, object>> path)
        {
            this.query = this.query.OrderByDescending(path);
            return this;
        }
        public IQueryBuilder<T> Page(int page, int pageSize)
        {
            this.query = this.query.Skip(page * pageSize).Take(pageSize);
            return this;
        }
        public T FirstOrDefault()
        {
            return this.query.FirstOrDefault<T>();
        }
        public Task<T> FirstOrDefaultAsync()
        {
            return this.query.FirstOrDefaultAsync();
        }
        public List<T> ToList()
        {
            return this.query.ToList();
        }
        public Task<List<T>> ToListAsync()
        {
            return this.query.ToListAsync();
        }
        public int Count()
        {
            return this.query.Count();
        }
        public Task<int> CountAsync()
        {
            return this.query.CountAsync();
        }
    }
