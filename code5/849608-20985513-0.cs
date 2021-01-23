    using System;
    using System.Web;
    using System.Web.Mvc;
    using XXXX.Online.Session;
    using XXXX.Online.Enums;
     
     namespace XXXX.Online.Web.Areas.api.Helpers
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
        public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
               try
               {
                   PayNet.Online.Web.Security.CheckSession(System.Web.HttpContext.Current);
               }
               catch
               {
                   // Get the redirection URL for the request from the system.web/authentication section in the the web.config.
                   var authenticationSection = (System.Web.Configuration.AuthenticationSection)System.Configuration.ConfigurationManager.GetSection("system.web/authentication");
                   System.Web.Configuration.FormsAuthenticationConfiguration formsAuthentication = authenticationSection.Forms;
                   string currentLoginUrl = formsAuthentication.LoginUrl;
     
                   HttpContext.Current.Response.Redirect(currentLoginUrl, true);
               }
          }
       }
    }
