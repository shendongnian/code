    public class ApplicationDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DBSet<Actor> Actors { get; set; }
    }
