    public Box(ILifetimeScope scope)
    {
        ILifetimeScope subScope = scope.BeginLifetimeScope();
        scope.Disposer.AddInstanceForDisposal(subScope);
        DbContext dbContext = subScope.Resolve<DbContext>(); 
        // no need to dispose subScope, 
        // subScope (and dbContext) will be disposed at the same time as scope
    }
