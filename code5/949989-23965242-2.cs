    public class MyDbContext : DbContext
    {
        public IDbSet<ComputedKey> ComputedKeys { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Computed Key:
            modelBuilder.Entity<ComputedKey>()
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
    
    public class ComputedKey
    {
        public int Id { get; set; }
    }
