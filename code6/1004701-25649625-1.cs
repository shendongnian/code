    // Global.asax.cs
    public class Global : HttpApplication
    {
        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie decryptedCookie =
                Context.Request.Cookies[FormsAuthentication.FormsCookieName];
    
            if (decryptedCookie != null)
            {
                FormsAuthenticationTicket ticket =
                    FormsAuthentication.Decrypt(decryptedCookie.Value);
    
                var identity = new GenericIdentity(ticket.Name);
                var principal = new GenericPrincipal(identity, null);
    
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = HttpContext.Current.User;
            }
        }
    }
