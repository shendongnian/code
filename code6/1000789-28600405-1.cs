    private void InitializeDatabase()
    {
        Database.SetInitializer(new DatabaseInitializer());
        if (!Database.Exists())
        {
            Database.Initialize(true);
        }            
    }
