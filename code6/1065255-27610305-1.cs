    public class BaseController : Controller
    {
         public override void OnActionExecuted(ActionExecutedContext filterContext)
         {
             filterContext.HttpContext.Session["KeepSessionAlive"] = DateTime.Now;
         }
    }
