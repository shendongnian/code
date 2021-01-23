    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       public ApplicationDbContext()
        : base("AIEntities", throwIfV1Schema: false)
       {
       }
       public static ApplicationDbContext Create()
      {
         return new ApplicationDbContext();
      }
    }
