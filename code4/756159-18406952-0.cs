    public class CustomAuthorizationFilter : ActionFilterAttribute
    {
        private readonly IAccountBL accountBL;
        public CustomAuthorizationFilter(IAccountBL accountBL)
        {
            this.accountBL = accountBL;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<CustomAuthorizationAttribute>().Any() || 
                actionContext.ActionDescriptor.GetCustomAttributes<CustomAuthorizationAttribute>().Any())
            {
                // here you know that the controller or action is decorated 
                // with the marker attribute so that you could put your code
            }
        }
    }
