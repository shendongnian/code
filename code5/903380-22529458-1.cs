    public abstract class Video
    {
        public int Id { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
    public class Youtube : Video
    {
        /* Other properties */
    }
    public class Vimeo : Video
    {
        /* Other properties */
    }
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }
    }
    public class VideoContext : DbContext
    {
        public DbSet<Youtube> Youtubes { get; set; }
        public DbSet<Vimeo> Vimeos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
