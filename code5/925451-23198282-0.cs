    public T Create<T>(T entity) where T : class
            {
                var newEntry = _dbContext.Set<T>().Add(entity);
    
                _dbContext.SaveChanges();
    
                return newEntry;
            }
