    using System.Data.Entity.Migrations;
    internal sealed class Configuration : DbMigrationsConfiguration<MySqlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
