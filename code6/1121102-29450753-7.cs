    public virtual void Remove(object entity)
    {
        DebugCheck.NotNull(entity);
        if (!(entity is TEntity))
        {
          throw Error.DbSet_BadTypeForAddAttachRemove("Remove", entity.GetType().Name, typeof(TEntity).Name);
        }
        InternalContext.DetectChanges();
        InternalContext.ObjectContext.DeleteObject(entity);
    }
