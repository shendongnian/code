    public class IncludePreferencesAttribute : ActionFilterAttribute
    {
           public override void OnActionExecuting(ActionExecutingContext filterContext)
           {
                  var controller = filterContext.Controller as BaseController;
        
                  // IController is not necessarily a Controller
        	      if (controller != null)
        	      {
                         //I have my preferences in the BaseController
                         //and cached but here you can query the DB
                         controller.ViewBag.MyPreferences = controller.TenantPreferences;
        	      }
           }
    }
