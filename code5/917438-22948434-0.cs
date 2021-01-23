    namespace ASPNetMVC53rdPartyAuth
    {
        public partial class Startup
        {
            public void ConfigureAuth(IAppBuilder app)
            {
            // Enable the application to use a cookie to store information for the signed    
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a              
            // third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // third party login providers: 
  
            // You have to register this app at https://developers.facebook.com/ and get the     
            //appId and appSecret.   
            // Facebook requires SSL, so that need to be enanbled.  Project url can be found  
            // under project properties and can be localhost.
             app.UseFacebookAuthentication(
               appId: "xxxxxxxxxxxxxxxx",
               appSecret: "xxxxxxxxxxxxxxxx");
             );           
        }
    }
}`
