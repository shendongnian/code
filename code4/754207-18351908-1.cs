    public static void InitializeDatabaseConnection()
    {
        using(var context = new EntitiesNew())
        {
            context.Database.Initialize(false);
        }
    }
