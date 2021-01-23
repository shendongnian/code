    public class Configuration : DbMigrationsConfiguration<YourDbContext>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
             }
    
            protected override void Seed(YourDbContext context)
            {
               base.Seed(context);
               
            }
        }
