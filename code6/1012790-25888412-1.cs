    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new PermissionAuthorizationFilter(
                () => Global.Container.GetInstance<IUserPermissionChecker>()), 0);
            filters.Add(new HandleErrorAttribute());
        }
    }
    public sealed class PermissionAuthorizationFilter : IAuthorizationFilter
    {
        private readonly Func<IUserPermissionChecker> userPermissionCheckerFactory;
        public PermissionAuthorizationFilter(
            Func<IUserPermissionChecker> userPermissionCheckerFactory) {
            this.userPermissionCheckerFactory = userPermissionCheckerFactory;
        }
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
            var permissionChecker = userPermissionCheckerFactory.Invoke();
            if (!permissionChecker.HasPermission(permissionId))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
