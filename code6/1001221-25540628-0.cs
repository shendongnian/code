    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AppContext"; // don't forget to match this key if create the class manually
        }
        protected override void Seed(AppContext context)
        {
        }
    }
