    public static void RecreateDatabase(string schemaScript)
    {   
        Database.Delete(); // Opens and disposes its own connection
        using (DbContext context = new DbContext("connectionStringName")) // New connection
        {
            Database database = context.Database;
            database.Create(); // Works!
            database.ExecuteSqlCommand(schemaScript);
        }
    }
