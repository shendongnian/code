    public string[] GetKeyNames<TEntity>() where TEntity : class
    {
        var set = ((IObjectContextAdapter)this).ObjectContext.CreateObjectSet<TEntity>();
        var entitySet = set.EntitySet;
        return entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
    }
