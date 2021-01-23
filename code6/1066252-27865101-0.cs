    public class Movie
    {
        public int Id { get; set; }
        public int ThumbnailId { get; set; }
        public virtual Thumbnail Thumbnail { get; set; }  // This property must be declared virtual
        public string Name { get; set; }
        // other properties
    }
    public class Thumbnail
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
    public class MoviesContext : DbContext
    {
        public MoviesContext(string connectionString)
            : base(connectionString)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
    }
