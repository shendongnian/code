    public class ApplicationUser : IdentityUser
    {
      [StringLength(200)]
      public override string UserName { get; set; }   
    }
