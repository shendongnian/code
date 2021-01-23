    public async Task<int> SaveOrUpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IContextEntity
        {
            if (entity.Id == 0)
                context.Set<TEntity>().Add(entity);
            else
            {
                TEntity dbEntry = context.Set<TEntity>().Find(entity.Id);
                if (dbEntry != null) dbEntry = entity;
            }
            return await context.SaveChangesAsync().ConfigureAwait(continueOnCapturedContext: false);
        }
