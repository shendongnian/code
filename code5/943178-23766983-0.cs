    public class PlayerDBContext : DbContext
    {
        public DbSet<Abbreviations> Abbrvs { get; set; }
        public DbSet<Team> Teams{ get; set; }
        //and any other context specific information OnModelCreating, SaveChanges, etc
    }
