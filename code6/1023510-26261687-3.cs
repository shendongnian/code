    public class Post
    {
         public int PostId { get; set; }
         public string Title { get; set; }
         public string Body { get; set; }
         public virtual ICollection<Category> Category { get; set; }
         public DateTime PublishDate { get; set; }
         public DateTime CreateDate { get; set; }
         //---------------------Here is the point
         public string PostCreatedBy { get; set; }
         public string PostModifiedBy { get; set; }
         [ForeignKey("PostCreatedBy"), InverseProperty("PostsCreated")]
         public virtual ApplicationUser CreatedBy { get; set; }
         [ForeignKey("PostModifiedBy"), InverseProperty("PostsModified")]
         public virtual ApplicationUser ModifiedBy { get; set; }
         //-------------------------------------------
         public DateTime ModifiedDate { get; set; }
         public Public Public { get; set; }
    }
 
