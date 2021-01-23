    public class MyDb : DbContext
    {
        public IDbSet<Track> Tracks { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>()
               .HasMany(t => t.Categories)
               .WithMany()
               .Map(c => c.ToTable("CategoriesForTracks"));
        }
    } 
