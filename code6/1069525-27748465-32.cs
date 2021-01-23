    public class BloggingContext : DbContext
    {     
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("BLOGS");
            modelBuilder.Entity<Blog>().HasKey(t => t.BlogId);
            modelBuilder.Entity<Blog>().Property(t => t.BlogId).HasColumnName("BLOGID");
            modelBuilder.Entity<Blog>().Property(t => t.Name).HasColumnName("NAME");
            modelBuilder.Entity<Blog>().Property(t => t.Url).HasColumnName("URL");
           // The same with post
            //mapping one-to-many relationship
            modelBuilder.Entity<Post>().HasRequired(c => c.Blog)
           .WithMany(s => s.Posts)
           .HasForeignKey(c => c.BlogId);
    }
