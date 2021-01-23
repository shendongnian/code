    public MyContext()
        : this(null, "Name=MyContext")
    {
    }
    public MyContext(IClock clock, string connectionString)
        : base(connectionString)
    {
        _clock = clock;
        var objCtx = ((IObjectContextAdapter) this).ObjectContext;
        objCtx.ObjectMaterialized += ObjectMaterialized;
        objCtx.SavingChanges += ObjectContext_SavingChanges;
    }
