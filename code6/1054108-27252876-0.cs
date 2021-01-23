    [Table("UserProfile")]
    public class UserProfile
    {
         [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
         public int UserId { get; set; }
         public string UserName { get; set; }
                   
         public virtual Person personprofile { get; set; }
    }
