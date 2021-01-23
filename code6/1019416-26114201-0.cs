    public TLog GetMapped<TEntity, TLog>(TEntity entity)
    {
        if(typeof(TEntity) == typeof(Branch) && typeof(TLog) == typeof(BranchLog))
        {
            B b = new B();
            return b.Get(entity);
        }
        return null;
    }
