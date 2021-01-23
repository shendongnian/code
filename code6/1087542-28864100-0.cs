    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {
        public string IdentityRoles
        {
            get { return _identityRoles ?? String.Empty; }
            set
            {
                _identityRoles = value;
                _identityRolesSplit = SplitString(value);
            }
        }
        private string _identityRoles;
        private string[] _identityRolesSplit = new string[0];
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //do the base class AuthorizeCore first
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            if (_identityRolesSplit.Length > 0)
            {
                //get the UserManager
                 using(var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
                {
                    var id = HttpContext.Current.User.Identity.GetUserId();
                    //get the Roles for this user
                    var roles = um.GetRoles(id);
                    //if the at least one of the Roles of the User is in the IdentityRoles list return true
                    if (_identityRolesSplit.Any(roles.Contains))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
          
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //if the user is not logged in use the deafult HandleUnauthorizedRequest and redirect to the login page
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            //if the user is logged in but is trying to access a page he/she doesn't have the right for show the access denied page
            {
                filterContext.Result =  new RedirectResult("/AccessDenied");
            }
        }
        protected static string[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new string[0];
            }
            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }
    }
