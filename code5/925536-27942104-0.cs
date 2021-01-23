        protected virtual DbContext GetDbContext()
        {
            return new ModelContext();
        }
        private DbContext GetDbContext(bool canUseCachedContext)
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
            _dbContext = this.GetDbContext();
            return _dbContext;
        }
