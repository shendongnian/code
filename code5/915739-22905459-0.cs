    public virtual void Save(TEntity entity)
    {
        // assuming TEntity as property "Id" [Key] of type int
        ((IObjectState) entity).ObjectState = entity.Id <= 0 ? ObjectState.Added : ObjectState.Modified;
        _dbSet.Attach(entity);
        _context.SyncObjectState(entity);
    }
