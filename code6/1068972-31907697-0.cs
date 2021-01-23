    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            var dataDirPath = "<YourPath>";
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirPath);
        }
    }
