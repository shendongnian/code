    public class CachingFilterAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext 
        filterContext)
      {
        // set VaryByHeaders the way you need
      }
     }
     [CachingFilter]
     public MyController : Controller...
