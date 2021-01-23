    internal sealed class PictureDBContextConfiguration : DbMigrationsConfiguration<PictureDBContext>
    {
        public PictureDBContextConfiguration()
        {
            AutomaticMigrationsEnabled = true; // This will allow CodeFirst to create the missing tables/columns
            AutomaticMigrationDataLossAllowed = true;  //This will allow CodeFirst to Drop column or even drop tables
        }
    }
