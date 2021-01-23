    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContainer _container;
        public UnitOfWork(IContainer container) :this()
        {
            _container = container;
        }
        //private readonly List<CommitInterception> _postInterceptions = new List<CommitInterception>(); 
        
        public DataContext Context { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            Context = new DataContext();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Dispose()
        {
            //Chuck was here
            try
            {
                Commit();
            }
            finally
            {
                Context.Dispose();   
            }
        }
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>IUnitOfWorkTransaction.</returns>
        public IUnitOfWorkTransaction BeginTransaction()
        {
            return new UnitOfWorkTransaction(this);
        }
        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            Commit(null);
        }
        /// <summary>
        /// Commits transaction.
        /// </summary>
        public void Commit(DbContextTransaction transaction)
        {
            //Lee was here.
            try
            {
                Context.SaveChanges();
                if (transaction != null)
                {
                    transaction.Commit();
                }
                //foreach (var interception in _postInterceptions)
                //{
                //    interception.PostCommit(interception.Instance, this);
                //}
            }
            catch (DbEntityValidationException ex)
            {
                var errors = FormatError(ex);
                throw new Exception(errors, ex);
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw;
            }
            finally
            {
               // _postInterceptions.Clear();
            }
        }
        /// <summary>
        /// Formats the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>System.String.</returns>
        private static string FormatError(DbEntityValidationException ex)
        {
            var build = new StringBuilder();
            foreach (var error in ex.EntityValidationErrors)
            {
                var errorBuilder = new StringBuilder();
                foreach (var validationError in error.ValidationErrors)
                {
                    errorBuilder.AppendLine(string.Format("Property '{0}' errored:{1}", validationError.PropertyName, validationError.ErrorMessage));
                }
                build.AppendLine(errorBuilder.ToString());
            }
            return build.ToString();
        }
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>``0.</returns>
        public T Insert<T>(T entity) where T: class
        {
            var instance = _container.TryGetInstance<IUnitOfWorkInterception<T>>();
            if (instance != null)
            {
                instance.Intercept(entity, this);
               // _postInterceptions.Add(new CommitInterception() { Instance = entity, PostCommit = (d,f) => instance.PostCommit(d as T, f) });
            }
            
            var set = Context.Set<T>();
            var item = set.Add(entity);
            return item;
        }
        public T Update<T>(T entity) where T : class
        {
            var set = Context.Set<T>();
            set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            var set = Context.Set<T>();
            set.Remove(entity);
        }
        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{``0}.</returns>
        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var set = Context.Set<T>();
           return set.Where(predicate);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IQueryable{``0}.</returns>
        public IQueryable<T> GetAll<T>() where T : class
        {
            return Context.Set<T>();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>``0.</returns>
        public T GetById<T>(int id) where T : class
        {
            var set = Context.Set<T>();
            return set.Find(id);
        }
        /// <summary>
        /// Executes the query command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns>DbSqlQuery{``0}.</returns>
        public DbSqlQuery<T> ExecuteQueryCommand<T>(string sql) where T : class
        {
            var set = Context.Set<T>();
            return set.SqlQuery(sql);
        }
        private class CommitInterception
        {
            public object Instance { get; set; }
            public Action<object, IUnitOfWork> PostCommit { get; set; } 
        }
    }
    public class UnitOfWorkTransaction : IUnitOfWorkTransaction
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly DbContextTransaction _transaction;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkTransaction"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public UnitOfWorkTransaction(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _transaction = _unitOfWork.Context.Database.BeginTransaction();
            Context = unitOfWork.Context;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _unitOfWork.Commit(_transaction);
        }
        public DataContext Context { get; set; }
        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            _unitOfWork.Commit();
        }
        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
        }
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public T Insert<T>(T entity) where T : class
        {
            return _unitOfWork.Insert(entity);
        }
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public T Update<T>(T entity) where T : class
        {
            return _unitOfWork.Update(entity);
        }
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            _unitOfWork.Delete(entity);
        }
        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
           return _unitOfWork.Find(predicate);
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> GetAll<T>() where T : class
        {
            return _unitOfWork.GetAll<T>();
        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public T GetById<T>(int id) where T : class
        {
           return _unitOfWork.GetById<T>(id);
        }
        /// <summary>
        /// Executes the query command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns>DbSqlQuery&lt;T&gt;.</returns>
        public DbSqlQuery<T> ExecuteQueryCommand<T>(string sql) where T : class
        {
           return _unitOfWork.ExecuteQueryCommand<T>(sql);
        }
    }
