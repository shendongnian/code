    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationServices")
        {
        }
    }
    public class MyUserManager : UserManager<ApplicationUser>
    {
        public MyUserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
            this.PasswordHasher = new SQLPasswordHasher();
        }
        public class SQLPasswordHasher : PasswordHasher
    [etc.]
