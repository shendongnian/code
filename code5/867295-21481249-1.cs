    public class BaseUnitOfWork // YOUR INTERFACES HERE
    {
        /// <summary>
        /// DB context.
        /// </summary>
        private IDBManager _dbManager;
        /// <summary>
        /// Repository provider class which can create repositories on demand.
        /// </summary>
        private IRepositoryProvider _repositoryProvider;
        public BaseUnitOfWork(IDBManager dbManager, IRepositoryProvider repoProvider)
        {
            _dbManager = dbManager;
            _repositoryProvider = repoProvider;
        }
        public T GetRepository<T>()
        {
            return _repositoryProvider.Create<T>(_dbManager);
        }
    }
    public class ReadOnlyUnitOfWork : BaseUnitOfWork
    {
        public ReadOnlyUnitOfWork(IDBManager dbManager, IRepositoryProvider repoProvider) : base(dbManager,repoProvider)
        {
            _dbManager = dbManager;
            _repositoryProvider = repoProvider;
        }
    }
    public class ReadWriteUnitOfWork : BaseUnitOfWork// YOUR INTERFACES HERE
    {
        private TransactionScope _transaction;
    
        public ReadWriteUnitOfWork(IDBManager dbManager, IRepositoryProvider repoProvider) : base(dbManager,repoProvider)
        {
            if (_transaction == null)
                _transaction = new TransactionScope();
        }
    
        public void Save()
        {
            _transaction.Complete();
        }
    
        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
