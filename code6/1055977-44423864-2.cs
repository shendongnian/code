    public static void RecreateDatabase(string schemaScript)
    {   
        using (DbContext context = new DbContext("connectionStringName"))
        {
            context.Database.Delete(); // Delete returns true, but...
            Database database = context.Database;
            database.Create(); // Database already exists!
            database.ExecuteSqlCommand(schemaScript);
        }
    }
