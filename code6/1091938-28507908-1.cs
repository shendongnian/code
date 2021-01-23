        public class YourContext: DbContext 
        {
            public YourContext(): base("DefaultConnectionString") 
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<YourContext, YourProject.Migrations.Configuration>("DefaultConnectionString"));    
            }
        }
