            public static void RegisterTypes(IUnityContainer container)
            {
                // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
                // container.LoadConfiguration();
                // TODO: Register your types here
                container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
                container.RegisterType<UserManager<ApplicationUser>>();
                container.RegisterType<DbContext, ApplicationDbContext>();
                container.RegisterType<ApplicationUserManager>();
                container.RegisterType<AccountController>(new InjectionConstructor());
            }
