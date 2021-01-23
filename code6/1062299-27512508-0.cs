    [Table("InternalBlogs")]
    public class Blog
    {   
        [Column("BlogDescription", TypeName="ntext")]
        public String Description {get;set;}
    }
