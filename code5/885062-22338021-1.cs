    class DataContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasMany(item => item.Recipe)
                .WithMany();
        }
    }
