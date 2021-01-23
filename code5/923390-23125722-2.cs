    // in Config
    public static string SQLITE_CONNECTION_CLASS_AQN = typeof(Mono.Data.Sqlite.SqliteConnection).AssemblyQualifiedName
    
    
    // in database class
    static string _connection_string = "Data Source=" + Config.SQLITE_DB_FILE + ";DbLinqProvider=sqlite;DbLinqConnectionType=" + Config.SQLITE_CONNECTION_CLASS_AQN + ";";
    
    
    // in database method
    Status data = GetStatusFoo();
    using (DataContext db = new DataContext(_connection_string))
    {
        Table<Status> statuses = db.GetTable<Status>();
        statuses.InsertOnSubmit(data);
        db.SubmitChanges();
    }
