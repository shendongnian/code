    public sealed class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbSet<T> _dbSet;
        private readonly IUoW _uoW;
        public GenericRepository(IUoW unitOfWork)
        {
            _uoW = unitOfWork;
            _dbSet = _uoW.Set<T>();
        }
        
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "", int? page = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            List<string> properties = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            properties.ForEach(property =>
                {
                    query = query.Include(property);
                });
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }
    // other methods like Delete, Update and GetById
    }
