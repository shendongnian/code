    using(var db = new VMaxEntities())
    {
       var connectionString = context.Database.Connection.ConnectionString;
       var datasource = context.Database.Connection.DataSource;
       var databaseServer = "yourDevDatabaseServerName"        
       db.Database.Connection.ConnectionString = connectionString.Replace(datasource, databaseServer);
    }
