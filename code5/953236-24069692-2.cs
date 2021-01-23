    public class EntityRepository<TEntity, TId>
        : IEntityRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IComparable
    {
        private readonly IEntityContext _dbContext;
        public EntityRepository(IEntityContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            _dbContext = dbContext;
        }
        public IQueryable<TEntity> GetAllIncluding(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>> orderBy,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                IQueryable<TEntity> queryable = GetAll(where, orderBy);
                foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
                {
                    queryable =
                        queryable.Include<TEntity, object>(includeProperty);
                }
                return queryable;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TEntity GetSingleIncluding(
            TId id,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            try
            {
                IQueryable<TEntity> entities =
                        GetAllIncluding(null, null, includeProperties);
                TEntity entity =
                    Filter<TId>(entities, x => x.Id, id).FirstOrDefault();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Add(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                if (this.EntityAdded != null)
                    this.EntityAdded(this, new EntityAddedEventArgs<TEntity, TId>(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Attach(TEntity entity)
        {
            try
            {
                _dbContext.SetAsAdded(entity);
                if (this.EntityAttach != null)
                    this.EntityAttach(this, new EntityAddedEventArgs<TEntity, TId>(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Edit(TEntity entity)
        {
            try
            {
                _dbContext.SetAsModified(entity);
                if (this.EntityModified != null)
                    this.EntityModified(this, new EntityModifiedEventArgs<TEntity, TId>(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(TEntity entity)
        {
            try
            {
                _dbContext.SetAsDeleted(entity);
                if (this.EntityDeleted != null)
                    this.EntityDeleted(this, new EntityDeletedEventArgs<TEntity, TId>(entity));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int Save()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> where = null,
            Expression<Func<TEntity, object>> orderBy = null)
        {
            try
            {
                IQueryable<TEntity> queryable =
                    (where != null) ? _dbContext.Set<TEntity>().Where(where)
                    : _dbContext.Set<TEntity>();
                return (orderBy != null) ? queryable.OrderBy(orderBy)
                    : queryable;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TEntity GetSingle(TId id)
        {
            try
            {
                IQueryable<TEntity> entities = GetAll();
                TEntity entity =
                    Filter<TId>(entities, x => x.Id, id).FirstOrDefault();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        #region Private
        private IQueryable<TEntity> Filter<TProperty>(
            IQueryable<TEntity> dbSet,
            Expression<Func<TEntity, TProperty>> property, TProperty value)
            where TProperty : IComparable
        {
            try
            {
                var memberExpression = property.Body as MemberExpression;
                if (memberExpression == null ||
                    !(memberExpression.Member is PropertyInfo))
                    throw new ArgumentException
                        ("Property expected", "property");
                Expression left = property.Body;
                Expression right =
                    Expression.Constant(value, typeof(TProperty));
                Expression searchExpression = Expression.Equal(left, right);
                Expression<Func<TEntity, bool>> lambda =
                    Expression.Lambda<Func<TEntity, bool>>(
                        searchExpression,
                        new ParameterExpression[] { property.Parameters.Single() });
                return dbSet.Where(lambda);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private enum OrderByType
        {
            Ascending,
            Descending
        }
        #endregion
    }
