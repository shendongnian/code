    [Import(typeof(IQueryEngine), RequiredCreationPolicy = CreationPolicy.Shared)]
    public IQueryEngine QueryEngine
    {
        get { return _queryEngine; }
        set
        {
            _queryEngine = value;
        }
    }
