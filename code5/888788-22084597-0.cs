    public class HeaderFooterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Write("<header></header>");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.Write("<footer></footer>");
        }
    }
