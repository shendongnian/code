    private static void InitializeUserManager(ApplicationUserManager manager, IAppBuilder app)
            {
                manager.UserValidator = new UserValidator<AspNetApplicationUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };
    
                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };
    
                var dataProtectionProvider = app.GetDataProtectionProvider();
    
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider = new DataProtectorTokenProvider<AspNetApplicationUser>(
                      dataProtectionProvider.Create("ASP.NET Identity"))
                    {
                        TokenLifespan = TimeSpan.FromHours(3)
                    };
                }
            }
