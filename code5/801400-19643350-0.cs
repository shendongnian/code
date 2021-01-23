    public class UseOptimisticConcurrencyScope : IDisposable
    {
        private DatabaseContext _dbContext;
        private bool _originalValue;
        
        public UseOptimisticConcurrency(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _originalValue = dbContext.Advanced.UseOptimisticConcurrency;
            
            dbContext.Advanced.UseOptimisticConcurrency = false;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinaliz(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Advanced.UseOptimisticConcurrency = _originalValue;
            }
        }
    }
