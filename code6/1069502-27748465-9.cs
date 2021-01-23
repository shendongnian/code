    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogsMap()
        {
            ToTable("BLOG");
            HasKey(t => t.BlogId);
            Property(t => t.BlogId).HasColumnName("BLOGID");
            Property(t => t.Name).HasColumnName("NAME");
            Property(t => t.Url).HasColumnName("URL");
        }
    }
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostsMap()
        {
            ToTable("POSTS");
            HasKey(t => t.PostId);
            Property(t => t.Text).HasColumnName("TEXT");
          //mapping the relationship
            HasRequired(c => c.Blog)
            .WithMany(s => s.Posts)
            .HasForeignKey(c => c.BlogId);
        }
    }
