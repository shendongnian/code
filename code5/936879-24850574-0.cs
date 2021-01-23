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
            unityContainer.RegisterType<IUserStore<ApplicationUser, int>, UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>>(new InjectionConstructor(new ApplicationDbContext()));
            unityContainer.RegisterType<IIdentityMessageService, EmailService>();
        }
    }
	</code>
 2. ApplicationUserManager (I removed static method Create):
	<code>
	public class ApplicationUserManagerService : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManagerService(IUserStore<ApplicationUser, int> store, 
                                             IIdentityMessageService emailService,
                                             IDataProtectionProvider dataProtectionProvider)
                                             : base(store)
        {
            UserTokenProvider = new EmailTokenProvider<ApplicationUser, int>();
            EmailService = emailService;
            Configure(dataProtectionProvider);
        }
        private void Configure(IDataProtectionProvider dataProtectionProvider)
        {
            // Configure validation logic for usernames
            UserValidator = new UserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Your security code is: {0}"
            });
            RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is: {0}"
            });
            if (dataProtectionProvider != null)
            {
                UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }
    }
    </code>
 3. Controller
	<code>
            public class AccountController : Controller
            {
                private ApplicationUserManagerService _userManagerService;
                public AccountController(ApplicationUserManagerService userManagerService)
                {
                    Contract.Requires(userManagerService != null);
                    _userManagerService = userManagerService;
                }
           /*....*/
        }
	</code>
This works for me but please feel free to suggest better solution.
