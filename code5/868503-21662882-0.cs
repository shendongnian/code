    CustomAuthorize(UserRole="AUTHORIZED_ROLE");
----------
     public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
            public string UserRole { get; set; }
            protected IUnitOfWork uow = new UnitOfWork();
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var isAuthorized = base.AuthorizeCore(httpContext);
                if (!isAuthorized)
                {
                    return false;
                }
                var currentUser;//Get Current User 
                if(UserRole==currentUser.Role.Name)
                {
                    return true;
                }
            
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {//redirect where you want to in case of not authorized.
                                controller = "Home",
                                action = "AccessDenied" 
                            })
                        );
        }
