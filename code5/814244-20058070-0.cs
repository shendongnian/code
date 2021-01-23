            // Configure the UserManager
            app.UseUserManagerFactory(new UserManagerOptions<ApplicationUser>()
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
                DataProtectionProvider = app.GetDataProtectionProvider(),
                Provider = new UserManagerProvider<ApplicationUser>()
                {
                    OnCreateStore = () => new UserStore<ApplicationUser>(new ApplicationDbContext())
                }
            });
