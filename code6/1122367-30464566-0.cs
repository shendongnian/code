    using System;
    using Microsoft.Azure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.DataProtection;
    using Owin.Security.Providers.Yahoo;
    using Owin.Security.Providers.LinkedIn;
    using Owin.Security.Providers.GitHub;
    using Owin.Security.Providers.Steam;
    using Owin.Security.Providers.StackExchange;
    using Microsoft.Owin.Security.Google;
    using Microsoft.Owin.Security.OAuth;
    using Owin;
    using JosephMCasey.Models;
    using JosephMCasey.Providers;
    using Microsoft.WindowsAzure.Management;
    
    namespace JosephMCasey
    {
        public partial class Startup
        {
            // Enable the application to use OAuthAuthorization. You can then secure your Web APIs
            static Startup()
            {
                PublicClientId = "web";
    
                OAuthOptions = new OAuthAuthorizationServerOptions
                {
                    TokenEndpointPath = new PathString("/Token"),
                    AuthorizeEndpointPath = new PathString("/Account/Authorize"),
                    Provider = new ApplicationOAuthProvider(PublicClientId),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                    AllowInsecureHttp = true
                };
            }
    
            public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
    
            public static string PublicClientId { get; private set; }
    
            // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
            public void ConfigureAuth(IAppBuilder app)
            {
                // Configure the db context, user manager and signin manager to use a single instance per request
                app.CreatePerOwinContext(ApplicationDbContext.Create);
                app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
                app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
    
                // Enable the application to use a cookie to store information for the signed in user
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    Provider = new CookieAuthenticationProvider
                    {
                        // Enables the application to validate the security stamp when the user logs in.
                        // This is a security feature which is used when you change a password or add an external login to your account.  
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(20),
                            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                    }
                });
                // Use a cookie to temporarily store information about a user logging in with a third party login provider
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    
                // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
                app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
    
                // Enables the application to remember the second login verification factor such as phone or email.
                // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
                // This is similar to the RememberMe option when you log in.
                app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
    
                // Enable the application to use bearer tokens to authenticate users
                app.UseOAuthBearerTokens(OAuthOptions);
    
                // Uncomment the following lines to enable logging in with third party login providers
    
                app.UseMicrosoftAccountAuthentication(
                    clientId: CloudConfigurationManager.GetSetting("Microsoft-clientId"),
                    clientSecret: CloudConfigurationManager.GetSetting("Microsoft-clientSecret"));
    
                app.UseTwitterAuthentication(
                    consumerKey: CloudConfigurationManager.GetSetting("Twitter-consumerKey"),
                    consumerSecret: CloudConfigurationManager.GetSetting("Twitter-consumerSecret"));
    
                app.UseFacebookAuthentication(
                    appId: CloudConfigurationManager.GetSetting("Facebook-appId"),
                    appSecret: CloudConfigurationManager.GetSetting("Facebook-appSecret"));
    
                app.UseYahooAuthentication(
                    CloudConfigurationManager.GetSetting("Yahoo-clientId"),
                    CloudConfigurationManager.GetSetting("Yahoo-clientSecret"));
    
                app.UseGitHubAuthentication(
                clientId: CloudConfigurationManager.GetSetting("Github-clientId"),
                clientSecret: CloudConfigurationManager.GetSetting("Github-clientSecret"));
    
                app.UseLinkedInAuthentication(CloudConfigurationManager.GetSetting("LinkedIn-clientId"), CloudConfigurationManager.GetSetting("LinkedIn-clientSecret"));
    
                app.UseSteamAuthentication(CloudConfigurationManager.GetSetting("Steam-key"));
    
                app.UseStackExchangeAuthentication(
                clientId: CloudConfigurationManager.GetSetting("StackExchange-clientId"),
                clientSecret: CloudConfigurationManager.GetSetting("StackExchange-clientSecret"),
                key: CloudConfigurationManager.GetSetting("StackExchange-key"));
    
                app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
                {
                    ClientId = CloudConfigurationManager.GetSetting("Google-clientId"),
                    ClientSecret = CloudConfigurationManager.GetSetting("Google-clientSecret")
                });
            }
        }
    }
