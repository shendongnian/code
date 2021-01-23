    public class LogResponseBodyInterceptorAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext?.Response?.Content is ObjectContent)
            {
                actionExecutedContext.Request.GetOwinContext().Environment["log-responseBody"] =
                    await actionExecutedContext.Response.Content.ReadAsStringAsync();
            }
        }
    }
