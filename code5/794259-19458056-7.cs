    public class UserPermissionsAttribute : AuthorizeAttribute
    {
        public IEnumerable<UserPermissions> PermissionsRequired { get; set; }
        public UserPermissionsAttribute()
        {
        }
        public UserPermissionsAttribute(params UserPermissions[] permissionsRequired)
        {
            PermissionsRequired = permissionsRequired;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.User; // get user from DB
            if (PermissionsRequired.All(x => user.Permissions.Any(y => x == y)))
            {
                // all permissions are met
                base.OnAuthorization(filterContext);
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
            base.OnAuthorization(filterContext);
        }
    }
