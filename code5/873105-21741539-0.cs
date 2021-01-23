    public class NoResponseCookieAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            System.Web.HttpContext.Current.Items.Add("remove-auth-cookie", "true");
        }
    }
