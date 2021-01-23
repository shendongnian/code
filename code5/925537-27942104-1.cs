        private DbContext GetDbContext()
        {
            return this.GetDbContext(false);
        }
        protected virtual DbContext GetDbContext(bool canUseCachedContext)
        {
            if (_dbContext != null)
            {
                if (canUseCachedContext)
                {
                    return _dbContext;
                }
                else
                {
                    _dbContext.Dispose();
                }
            }
            _dbContext = new ModelContext();
            return _dbContext;
        }
        #region IDisposable Members
        public void Dispose()
        {
            this.Dispose(true);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Clear down managed resources.
                    if (_dbContext != null)
                        _dbContext.Dispose();
                }
                _isDisposed = true;
            }
        }
        #endregion
