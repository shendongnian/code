      public abstract class Post {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } 
        // etc...
      }
    
      public class Article : Post {}
    
      public class News : Post {}
    
      public class Advertisement : Post {
        public DateTime ExpirationDate { get; set; }
      }
    
      public class Tag {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
      }
    
      public class PostsContext : DbContext {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
      }
