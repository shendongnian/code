    public class BaseAnonymousController : Controller
    {
        protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            if (filterContext.Controller.GetType().Name == "AccountController" && filterContext.ActionDescriptor.ActionName == "login")
            {
                Guid result;
                if (!string.IsNullOrEmpty(SessionVariables.UserId) && Guid.TryParse(SessionVariables.UserId, out result))
                {
                    //Already a anonymous user, so good to go.
                }
                else
                {
                    //Seems to be a logged in a user. So, clear the session
                    Session.Clear();
                }
            }
            //Perform a false authentication for anonymous users (signup, login, activation etc. views/actions) so that SignalR will have a user name to manage its connections
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
    }
