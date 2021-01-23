         using Microsoft.Owin.Security.DataProtection;
         var dataProtector = app.CreateDataProtector(new string[]   {
              typeof(OAuthAuthorizationServerMiddleware).Namespace,
              "Access_Token",
              "v1"
         });
