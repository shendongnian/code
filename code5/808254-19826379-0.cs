       public class Television
        {
            public int TelevisionID { get; set; }
            //
            public virtual ICollection<Room> Rooms { get; set; }
        }
    
        public class Room
        {
            public int RoomID { get; set; }
            //
            public virtual ICollection<Television> Televisions { get; set; }
    
        }
    
        public class YourDbContext : DbContext
        {
            public YourDbContext(): base("name=YourConnectionString")
            {
            }
            public DbSet<Television> Televisions { get; set; }
            public DbSet<Room> Rooms { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Television>()
                    .HasMany(n => n.Rooms)
                    .WithMany(n => n.Televisions)
                    .Map(n => n.MapLeftKey("TelevisionID")
                        .MapRightKey("RoomID")
                        .ToTable("TelevisionRoom"));
            }
        }
