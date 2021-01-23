    public class ADUserActionFilterAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        // Do database stuff
      }
    }
