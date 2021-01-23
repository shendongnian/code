    public class ApplicationUserManager : UserManager<ApplicationUser, Guid>
        {
            public ApplicationUserManager(IApplicationUserStore store)
                : base(store)
            {
            }
    
            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var manager = new ApplicationUserManager(new ApplicationUserStore(context.Get<ApplicationDbContext>())) { PasswordHasher = new CustomPasswordHasher() };
               
                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = false,
                };
                
                return manager;
            }
        }
