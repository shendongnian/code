    public MyContext() : base(ConnectionManager.Connection, true)
    {
        Database.SetInitializer<MyContext>(new MyContextInitializer());
        Configuration.ProxyCreationEnabled = false;
    }
    public MyContext(DbConnection connection) : base(connection, true)
    {
        Database.SetInitializer<MyContext>(new MyContextInitializer());
        Configuration.ProxyCreationEnabled = false;
    }
