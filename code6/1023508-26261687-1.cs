    public class Post
    {
         public int PostId { get; set; }
         public string Title { get; set; }
         public string Body { get; set; }
         public virtual ICollection<Category> Category { get; set; }
         public DateTime PublishDate { get; set; }
         public DateTime CreateDate { get; set; }
         public ApplicationUser UserCreatedBy { get; set; }
         public ApplicationUser UserModifiedBy { get; set; }
         public DateTime ModifiedDate { get; set; }
         public Public Public { get; set; }
    }
