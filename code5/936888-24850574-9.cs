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
