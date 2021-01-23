    public static DbConnection GetOpenConnection()
    {
        // A SqlConnection, SqliteConnection ... or whatever
        var cnn = CreateRealConnection();
    
        // wrap the connection with a profiling connection that tracks timings 
        return new StackExchange.Profiling.Data.ProfiledDbConnection(cnn,
                                                    MiniProfiler.Current);
    }
    ...
    using(var Db = new MyEntities(GetOpenConnection()))
    {
        ...
    }
