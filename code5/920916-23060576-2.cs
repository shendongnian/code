    public virtual void Insert(TEntity entity)
    {
        //((IObjectState)entity).ObjectState = ObjectState.Added;
        context.TEntityDbSet.Add(entity);//Add, not Attach!
        //dataContext.SyncObjectState(entity);
        context.SaveChanges()
    }
