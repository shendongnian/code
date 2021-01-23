    public class MyFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                if (actionContext.Request.Method == HttpMethod.Post)
                {
                    var postData = actionContext.ActionArguments;
                    //do logging here
                }
            }
        }
