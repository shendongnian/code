    // using System.Web.Http.Filters;
    public class ConTypeFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            if (request.Content.Headers.ContentType==null)
            {
                request.Content.Headers.ContentType=new MediaTypeHeaderValue("application/json");
            }
        }
    }
