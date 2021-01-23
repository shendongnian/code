    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new PermissionAuthorizationFilter(), 0);
            filters.Add(new HandleErrorAttribute());
        }
    }
    public sealed class PermissionAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext) {
            var attribute = filterContext.ActionDescriptor
                .GetCustomAttributes(typeof(PermissionAttribute), true)
                .OfType<PermissionAttribute>()
                .SingleOrDefault();
            if (attribute != null) {
                VerifyPermission(filterContext, attribute.PermissionId);
            }
        }
        private static void VerifyPermission(AuthorizationContext filterContext,
            Guid permissionId) {
            // unfortunately we'll have to fall back to service location here
            var permissionChecker = 
                DependencyResolver.Current.GetInstance<IUserPermissionChecker>();
            if (!permissionChecker.HasPermission(permissionId))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
