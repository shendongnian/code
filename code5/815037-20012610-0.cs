    public class BaseController: Controller
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.Controller.ViewBag.PageTitle = "Show this text into my MasterPage";
                base.OnActionExecuted(filterContext);
            }
    }
