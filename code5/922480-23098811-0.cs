    public class User : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
      public int AgencyId { get; set; } //new
      public virtual Agency Agency { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
