    public TDestination Map<TDestination>(object source, 
                                          Action<IMappingOperationOptions> opts)
    {
        TDestination tDestination = default(TDestination);
        if (source != null)
        {
            Type type = source.GetType();
            Type type1 = typeof(TDestination);
            tDestination = (TDestination)this.Map(source, type, type1, opts);
        }
        return tDestination;
    }
