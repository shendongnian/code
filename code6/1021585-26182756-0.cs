    public interface IMyProj1DbContext : IDbContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Place> Places { get; set; }
    }
