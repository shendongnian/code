    public class MyDbContext : IdentityDbContext<ApplicationUser>
        {
            public MyDbContext()
                : base("DefaultConnection")
            {
            }
        }
