        public interface IDelete
        {
            bool IsDeleted { get; set; }
        }
        
        public class Blog : IDelete
        {        
            public int BlogId { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public List<Post> Posts { get; set; }
        }
        public class Post : IDelete
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public bool IsDeleted { get; set; }
            public int BlogId { get; set; }
            public Blog Blog { get; set; }
        }
        // Default method inside the DbContext or your default Context
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            base.OnModelCreating(builder);  
            modelBuilder.Entity<Blog>()
                        // Add Global filter to the Blog entity
                        .HasQueryFilter(p => p.IsDeleted == false);
            modelBuilder.Entity<Post>()
                        // Add Global filter to the Post entity
                        .HasQueryFilter(p => p.IsDeleted == false);
        }
