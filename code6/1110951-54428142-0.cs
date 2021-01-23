csharp
public class FooDbContextFactory : IDesignTimeDbContextFactory<FooDbContext>
{
    public FooDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
 
        var builder = new DbContextOptionsBuilder<FooDbContext>();
        var connectionString = configuration.GetConnectionString("ConnectionStringName");
        builder.UseSqlServer(connectionString);
 
        return new FooDbContext(builder.Options);
    }
}
