    public partial class Startup
    {
        static Startup()
        {
            UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>());
        }
        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }
        public void ConfigureAuth(IAppBuilder app)
        {
            var manager = UserManagerFactory();
            IDataProtectionProvider provider = app.GetDataProtectionProvider();
            if (provider != null)
            {
                manager.PasswordResetTokens = new DataProtectorTokenProvider(provider.Create("PasswordReset"));
                manager.UserConfirmationTokens = new DataProtectorTokenProvider(provider.Create("ConfirmUser"));
            }
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
