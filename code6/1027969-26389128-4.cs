    public virtual bool CheckExist<T>(T entity) where T : class
    {
        var context = new eTRIKSdataEntities();
        IQueryable<T> dbQuery = context.Set<T>();
        if (dbQuery.Any(e => e == entity))
        {
            return true;
        }
        return false;
    }
