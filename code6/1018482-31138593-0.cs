    public class AllowCrossDomain : System.Web.Http.Filters.ActionFilterAttribute
    {
       
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    //Note "*" will allow all - you can change this to only allow tursted domains
        }
    }
