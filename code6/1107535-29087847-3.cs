    app.UseOpenIdConnectAuthentication(
               new OpenIdConnectAuthenticationOptions
               {
                   ClientId = ClientId,
                   Authority = Authority,                   
                   Notifications = new OpenIdConnectAuthenticationNotifications()
                   {
                       
                       
                       RedirectToIdentityProvider = (context) =>
                       {
                           
                           if (context.Request.Path.Value == "/Account/ExternalLogin" || (context.Request.Path.Value == "/Account/LogOff" && context.Request.User.Identity.IsExternalUser()))
                           {
                               // This ensures that the address used for sign in and sign out is picked up dynamically from the request
                               // this allows you to deploy your app (to Azure Web Sites, for example)without having to change settings
                               // Remember that the base URL of the address used here must be provisioned in Azure AD beforehand.
                               string appBaseUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.PathBase;
                               context.ProtocolMessage.RedirectUri = appBaseUrl + "/";
                               context.ProtocolMessage.PostLogoutRedirectUri = appBaseUrl;
                           }
                           else
                           {
                               //This is to avoid being redirected to the microsoft login page when deep linking and not logged in 
                               context.State = Microsoft.Owin.Security.Notifications.NotificationResultState.Skipped;
                               context.HandleResponse();
                           }
                           return Task.FromResult(0);
                       },
                   }
               });
