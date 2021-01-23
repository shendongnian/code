    public class ConfigActionFilter : ActionFilterAttribute {   
      // This method is called before a controller action is executed.
      public override void OnActionExecuting(ActionExecutingContext filterContext) {
        if(someConfigSetting) {
          filterContext.Result = new RedirectToRouteResult("Error", someRouteValues);
        }
      }
      ...
    }
