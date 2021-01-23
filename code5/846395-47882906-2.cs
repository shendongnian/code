    public class ApplicationDbContext : DbContext
    {
        public DbSet<City> City { get; set; }
    }
    var Context = new  ApplicationDbContext();
