    protected virtual void InitializeDatabase()
    {
        if (!Database.Exists())
        {
            Database.Initialize(true);
            new DatabaseInitializer().Seed(this);
        }            
    }
