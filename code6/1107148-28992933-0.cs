    public class AppleMangoAuthorizeAttribute : AuthorizeAttibute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName.Contains("Apple") /*&& some other failing logic*/)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else if (/*same for mango*/)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
