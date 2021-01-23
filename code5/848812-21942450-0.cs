    public class MyCreateDatabaseIfNotExists : IDatabaseInitializer<FirebirdDbContext>
    {
        public void InitializeDatabase(FirebirdDbContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }
        }
    }
    
