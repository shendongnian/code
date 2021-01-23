      internal sealed class Configuration : DbMigrationsConfiguration<NetCollab.Web.Data.DataContext>
      {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "NetCollab.Web.Data.DataContext";
        }
        protected override void Seed(NetCollab.Web.Data.DataContext context)
        {
            //  This method will be called after migrating to the latest version.
             
        }
    }
