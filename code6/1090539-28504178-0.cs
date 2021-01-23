    private static bool _created = false;
    public ApplicationDbContext()
    {            
        // Create the database and schema if it doesn't exist
        // This is a temporary workaround to create database until Entity Framework database migrations 
        // are supported in ASP.NET 5
        if (!_created)
        {
            Database.AsMigrationsEnabled().ApplyMigrations();
            _created = true;
        }
    }
