    public class MyDbContextDesignTimeFactory : IDesignTimeDbContextFactory<LocationsDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            //TODO - use configuration file/environment variable
            return new MyDbContext(optionsBuilder.Options, new RepositoryConfiguration()
            {
                DefaultConnectionString = "theConnectionString"
            });
        }
    }
