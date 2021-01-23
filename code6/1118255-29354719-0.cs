     public class Post
     {
    
        public Post()
        {
            Contents = new List<PostContent>();
        }
        public int Id { set; get; }
        public bool Active { get; set; }
        public bool Featured { get; set; }
        PostContent EnglishContent {get;set;}
        PostContent ArabicContent {get;set;}
    
     }
    public class PostContent
    {
        public int Id { set; get; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
    
        [StringLength(2)]
        public string Culture { get; set; }/*This property is not required*/
    
        public virtual Post Post{ set; get; }
    }
               
    public class PostContentMap : EntityTypeConfiguration<PostContent>
    {
        public PostContentMap()
        {
            HasKey(p => p.Id);
    
            HasRequired(r => r.Post).WithRequiredDependent();
    
            ToTable("PostContents");
        }
    }
