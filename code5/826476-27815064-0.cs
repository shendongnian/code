    using System.Web;
    using System.Web.Http.Filters;
    ...
    public class AddCustomHeaderActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            actionExecutedContext.ActionContext.Response.Headers.Add("name", "value");
        }
    }
