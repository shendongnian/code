        System.Web.HttpContext.Current.GetOwinContext().Authentication.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
        FormsAuthentication.SignOut();
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        Request.GetOwinContext().Authentication.SignOut();
        Request.GetOwinContext().Authentication.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);
