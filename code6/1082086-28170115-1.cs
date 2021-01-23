    public class ApplicationUser : IdentityUser<KEY>
    {
         // ...
         public List<Country> Countries { get; set; }
    }
