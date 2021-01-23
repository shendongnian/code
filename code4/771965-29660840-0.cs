    MYContext localhostContext = new MYContext();
    MYContext LiveContext = new MYContext();
    //If your databases in different servers
    LiveContext.Database.Connection.ConnectionString = LiveContext.Database.Connection.ConnectionString.Replace("localhost", "Live");
    //If your databases have different Names
    LiveContext.Database.Connection.ConnectionString = LiveContext.Database.Connection.ConnectionString.Replace("DBName-Localhost", "DBName-Live");
