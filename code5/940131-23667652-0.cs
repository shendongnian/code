    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class SecureAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext) {
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            this.Roles = string.Join(",", MyRoleClass.GetAuthorizedRolesForThisAction(controller));
            base.OnAuthorization(filterContext);
        }
    }
