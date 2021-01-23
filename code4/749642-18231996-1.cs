    public virtual void Add(object entity)
    {
        ActOnSet(() => ((InternalSet<TEntity>) this).InternalContext.ObjectContext.AddObject(((InternalSet<TEntity>) this).EntitySetName, entity),  
                  EntityState.Added, entity, "Add");
    }
