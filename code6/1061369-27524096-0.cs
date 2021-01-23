     public class MyMigrationConfiguration : DbMigrationsConfiguration<MyMigrationContext>
    {
        public MyMigrationConfiguration ()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
	        MigrationsNamespace = "My.Migrations.Assembly";
	        MigrationsDirectory = "My/Migrations/Directory";
            ContextKey = "MyContexKey"; // You MUST set this for every migration context
        }
    }
