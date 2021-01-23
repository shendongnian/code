     public AccountController()
         : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
     {
         if (Startup.DataProtectionProvider != null)
         {
             this.UserManager.PasswordResetTokens = new DataProtectorTokenProvider(Startup.DataProtectionProvider.Create("PasswordReset"));
             this.UserManager.UserConfirmationTokens = new DataProtectorTokenProvider(Startup.DataProtectionProvider.Create("ConfirmUser"));
         }
     }
