    private volatile Type _dependency;
    
    public MyClass()
    {
        _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
    }
