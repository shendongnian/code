            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create, (options, manager) =>
            {
                options.DataProtectionProvider = app.GetDataProtectionProvider();
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(options.DataProtectionProvider.Create("AspNet.com"));
            });
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
