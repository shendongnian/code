    public class AppDbContext : DbContext
    {
        public DbSet<Furni> Furniture { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
