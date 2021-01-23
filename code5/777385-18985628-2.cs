    class MyFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            IEnumerable<string> values;
            if (actionContext.Request.Headers.TryGetValues("some_key", out values) && values.First() == "hello")
            {
    
            }
        }
    }
