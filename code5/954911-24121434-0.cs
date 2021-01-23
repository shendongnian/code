    public class SetLanguageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //Use actionContext.Request to access your request
        }
    }
