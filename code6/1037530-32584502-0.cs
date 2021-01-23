    public class AuthorizeByRolesAttribute : AuthorizeAttribute
    {
        private const string AuthorizedContextItemName = "_AuthorizedByRoles";
        public AuthorizeByRolesAttribute (params string[] roles)
        {
            this.Order = 0;
            this.Roles = string.Join (",", roles);
        }
        public override void OnAuthorization (AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Items[AuthorizedContextItemName] != null)
                return;
            base.OnAuthorization (filterContext);
            filterContext.RequestContext.HttpContext.Items[AuthorizedContextItemName] = this.Roles ?? string.Empty;
        }
    }
