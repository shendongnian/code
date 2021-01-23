     public class FilterBase : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                    if (!filterContext.IsChildAction && !filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        /*
                         * MICROSOFT BUG
                         * http://stackoverflow.com/questions/20737578/asp-net-sessionid-owin-cookies-do-not-send-to-browser/21234614#21234614
                         * https://katanaproject.codeplex.com/workitem/197
                         */
                        filterContext.HttpContext.Session["Workaround"] = 0;
                    }
                
            }
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                
            }
        }
