    public class ApplicationUserManager : UserManager<ApplicationUser, string>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser, string> store)
                : base(store)
            {
    
            }
    
            
        }
    public class ApplicationUserStore : UserStore<ApplicationUser, CustomRole, string, CustomUserLogin, CustomUserRole, CustomUserClaim>
        {
            public ApplicationUserStore(ApplicationDbContext context)
                : base(context)
            {
            }
        }
