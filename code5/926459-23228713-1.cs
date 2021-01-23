    public class AuthorizeDB : AuthorizeAttribute
    {
        ProjectDB db = new ProjectDB();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                return false;
            var name = httpContext.User.Identity.Name;
            return db.Users.FirstOrDefault(u => u.UserName == name) != null;
        }
    }
