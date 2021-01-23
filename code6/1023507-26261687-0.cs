    public class ApplicationUser : IdentityUser
    {
         [Required]
         [DataType(DataType.EmailAddress)]
         public string Email { get; set; }
         [InverseProperty("UserCreatedBy")]
         public virtual ICollection<Post> PostsCreated { get; set; }
         [InverseProperty("UserModifiedBy")]
         public virtual ICollection<Post> PostsModified { get; set; }
         public virtual Comment Comment { get; set; }
    }
