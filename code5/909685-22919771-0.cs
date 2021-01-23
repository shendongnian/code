    public enum ContentType
    {
        Text,
        Image,
        Video,
        Audio,
    }
    
    public class Content
    {
        public int Id { get; set; }
        public ContentType { get; set; }
    }
    public class TestContext : DbContext
    {
         public DbSet<Content> Contents { get; set; }
         public static List<Content> GetImages()
         {
              using (var context = new TestContext()
              {
                   return context.Contents
                                 .Where(c => c.ContentType == ContentType.Image)
                                 .ToList();              
              }
         }
    }
