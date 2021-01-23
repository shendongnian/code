    private readonly Func<IEntityContext> _entityContext;
        
                public BarService(Func<IEntityContext> entityContext)
                {
                    _entityContext = entityContext;
                }
