    public class XXActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            if ((context.Session[item] == null))
            {
                var result = new PartialViewResult
                {
                     ViewName = "PathToView"
                };
     
                filterContext.Result = result;
                return;              
            }
            base.OnActionExecuting(filterContext);
        }
    }
