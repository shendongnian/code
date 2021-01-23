    public class ApplicationUser : IdentityUser
    {
         [Required]
         [DataType(DataType.EmailAddress)]
         public string Email { get; set; }
         public virtual ICollection<Post> PostsCreated { get; set; }
         public virtual ICollection<Post> PostsModified { get; set; }
         public virtual Comment Comment { get; set; }
    }
