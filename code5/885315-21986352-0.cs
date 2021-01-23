    public class EnhanchedAuthorize : ActionFilterAttribute
    {
       public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
                BaseController controller = filterContext.Controller as BaseController;
    
                //use service now
                controller.UserService.CallMethod();
                .....
            }
    }
