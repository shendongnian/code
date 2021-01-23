    public class UriActionFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                // Sample: somehow identify the user, in case of a custom identity, replace the below line to get the user identifier
                var user = System.Threading.Thread.CurrentPrincipal.Identity.Name;
    
                // get the parameter that will let you know what is the image or path that is being requested now
                var ctxParams = filterContext.ActionParameters;
    
                // if the user does not have the permission to view, return 403
                filterContext.RequestContext.HttpContext.Response.StatusCode = 403;
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
