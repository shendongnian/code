    public class PermissionAttribute : AuthorizeAttribute
        {
            private readonly IAccountService _accountService;
            private readonly IEnumerable<PermissionEnum> _permissions;
    
            public PermissionAttribute(params PermissionEnum[] permissions):
                this(DependencyResolver.Current.GetService<IAccountService>())
            {
                _permissions = permissions;
            }
    
            protected PermissionAttribute(IAccountService accountService)
            {
                _accountService = accountService;
            }
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if(!_permissions.Any(x=>_accountService.HasPermission(filterContext.HttpContext.User.Identity.Name,(int)x)))
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                base.OnAuthorization(filterContext);
            }
    
        }
