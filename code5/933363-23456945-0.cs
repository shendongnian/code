    public void InsertOrUpdate(T entity, Expression<Func<T, bool>> Findpredicate)
    {   
        bool exists = this.FindBy(Findpredicate).Any();
        if (exists)
        {
            context.CreateObjectSet<T>().Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
        else
        {
            context.CreateObjectSet<T>().AddObject(entity);
        }
        context.SaveChanges();
    }
