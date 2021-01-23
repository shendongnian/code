    public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
            {
                //Setting validator to user name
                UserValidator = new UserValidator<ApplicationUser>(this)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };
    
                //Validation Logic and Password complexity 
                PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };
    
                //Lockout
                UserLockoutEnabledByDefault = true;
                DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                MaxFailedAccessAttemptsBeforeLockout = 5;
    
                // Providers de Two Factor Autentication
                RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<ApplicationUser>
                {
                    MessageFormat = "Seu código de segurança é: {0}"
                });
    
                RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<ApplicationUser>
                {
                    Subject = "Código de Segurança",
                    BodyFormat = "Seu código de segurança é: {0}"
                });
    
                //Email service
                EmailService = new EmailService();
    
                // Definindo a classe de serviço de SMS
                SmsService = new SmsService();
    
                var provider = new DpapiDataProtectionProvider("Braian");
                var dataProtector = provider.Create("ASP.NET Identity");
    
                UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtector);
    
            }
        }
