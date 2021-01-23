    private string dbPath = System.IO.Path.Combine
        (System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
         "MyDatabase.sqlite");
        
    using (var m_dbConnection = new SQLite.SQLiteConnection(dbPath)) {}
