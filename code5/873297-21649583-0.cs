    public class MetaDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var key = filterContext.RouteData.Values["id"];
            // using key get proper keywords and description for page
            filterContext.Controller.ViewBag.MetaKeywords = "1, 2, 3";
            filterContext.Controller.ViewBag.MetaDescription = "This is new description";
        }
    }
