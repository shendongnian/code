    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var authConfigurator = new AuthConfigurator();
            authConfigurator.ConfigureAuth(app);
            var unityContainer = UnityConfig<MvcUnityDependencyContainer>.UseContainer();
            //Asp identity registration
            IDataProtectionProvider dataProtectionProvider = app.GetDataProtectionProvider();
            unityContainer.RegisterInstance(dataProtectionProvider);
            unityContainer.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<UserManager<ApplicationUser, int>>(new HierarchicalLifetimeManager());
			unityContainer.RegisterType IIdentityMessageService, EmailService>();
            unityContainer.RegisterType<IUserStore<ApplicationUser, int>,
                UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>>(
                    new InjectionConstructor(new ApplicationDbContext()));
            unityContainer.RegisterType<IIdentityMessageService, EmailService>();
        }
    }
