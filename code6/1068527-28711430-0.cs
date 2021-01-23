    protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            //Perform a false authentication for anonymous users (signup, login, activation etc. views) so that SignalR will have a user name to manage its connections
            if (!string.IsNullOrEmpty(SessionVariables.UserId))
            {
                filterContext.HttpContext.User = new CustomPrincipal(new CustomIdentity(SessionVariables.UserId, "Anonymous"));
            }
            else
            {
                string userName = Guid.NewGuid().ToString();
                filterContext.HttpContext.User = new CustomPrincipal(new CustomIdentity(userName, "Anonymous"));
                FormsAuthentication.SetAuthCookie(userName, false);
                SessionVariables.UserId = userName;
            }
            base.OnAuthentication(filterContext);
        }
