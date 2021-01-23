    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<MobileSignIn> MobileSignIns { get; set; }
    }
    public class MobileSignIn
    {
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        : base("DefaultConnection")
        { }
    }
