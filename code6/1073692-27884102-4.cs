    public class YourContext : DbContext
    {
        //...
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().HasMany(p => p.Tags).WithMany(c => c.Photos).Map(c=>c.ToTable("PhotoTag"));
                
        } 
    }
