        public virtual void Update(TEntity entityToUpdate)
        {
            if (_db.Entry(entityToUpdate).State == EntityState.Added)
                return; // just been added leave state as added
            try
            {
                _dbSet.Attach(entityToUpdate);
            }
            catch (InvalidOperationException ex)
            {
                var trackedEntity = _dbSet.Find(GetKeyValues(entityToUpdate));
                if (trackedEntity == null)
                    throw;
                if (_db.Entry(trackedEntity).State != EntityState.Unchanged)
                    throw;
                _db.Entry(trackedEntity).State = EntityState.Detached;
                _dbSet.Attach(entityToUpdate);
            }
            _db.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public object[] GetKeyValues(TEntity entity)
        {
            var objectContextAdapter = ((IObjectContextAdapter)_db);
            var name = typeof(TEntity).Name;
            var entityKey = objectContextAdapter.ObjectContext.CreateEntityKey(name, entity);
            var result = entityKey.EntityKeyValues.Select(kv => kv.Value).ToArray();
            return result;
        }
