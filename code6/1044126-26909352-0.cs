     public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager()
                : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
            {
                PasswordValidator = new MinimumLengthValidator(4);
                UserValidator = new UserValidator<ApplicationUser>(this)
                { AllowOnlyAlphanumericUserNames = false  }; 
            }
        }
