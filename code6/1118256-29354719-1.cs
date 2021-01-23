     public class Post
     {
    
        public Post()
        {
            Contents = new List<PostContent>();
        }
        public int Id { set; get; }
        public bool Active { get; set; }
        public bool Featured { get; set; }
        public int? EnglishContentId { get;set;}
        public int? ArabicContentId { get;set;}
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
    
    }
               
        public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("Posts");
            HasOptional(p => p.EnglishContent).WithMany().HasForeignKey(p=>p.EnglishContentId);
            HasOptional(p => p.ArabicContent).WithMany().HasForeignKey(p=>p.ArabicContentId);
        }
    }
    
    public class PostContentMap : EntityTypeConfiguration<PostContent>
    {
        public PostContentMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("PostContents");
        }
    }
