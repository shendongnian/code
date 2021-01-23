    public Box(ILifetimeScope scope)
    {
        using (ILifetimeScope subScope = scope.BeginLifetimeScope())
        {
            DbContext dbContext = subScope.Resolve<DbContext>();
        }
    }
