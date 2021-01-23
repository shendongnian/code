    public class Post
    {
        public Post() { Tags = new List<Tag>(); }
        public int Id{ get; set; }
        public string Title{ get; set; }
        public string ShortDescription{ get; set; }
        public string Description{ get; set; }
        public string Meta{ get; set; }
        public string UrlSlug{ get; set; }
        public bool Published{ get; set; }
        public DateTime PostedOn{ get; set; }
        public DateTime? Modified{ get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
        public virtual IList<Tag> Tags{ get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
