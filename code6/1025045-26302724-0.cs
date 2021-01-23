    public class BookingsContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingBase>()
                .HasKey(p => p.BookingId)
                .Property(p => p.BookingId)
                           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Booking>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Booking");
                });
            modelBuilder.Entity<BookingHistory>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("BookingHistory");
                });
        }
    }
        
