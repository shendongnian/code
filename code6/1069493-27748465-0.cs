    [Table(“BLOGS”)]
    public class Blog
    {
        [Key]
        [Column(“BLOGID”)]
        public int BlogId { get; set; }
        [Column(“NAME”)]
        public string Name { get; set; }
        [Column(“URL”)]
        public string Url { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
    [Table(“POSTS”)]
    public class Post
    {
        [Key]
        [Column(“POSTID”)]
        public int PostId { get; set; }
        [Column(“TEXT”)]
        public string Text { get; set; }
        public int BlogId { get; set; }
 
        [ForeignKey("BlogId")]
        public virtual BaseCard Blog { get; set; }
    }
