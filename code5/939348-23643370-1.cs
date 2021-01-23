       public class SomeController : MyBaseMvcController{
        // whatever as usual....
       }
    [System.Web.Mvc.Authorize]
    [MyMVCFilter]  // see the filter below.  Get the MVC pipeline to call your code on Executing
    public abstract class MyBaseMvcController : Controller
    {
        protected MyBaseMvcController () {
              // a place to get a NEW uow or new Context ....
        }
    }
    public class MyMVCFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
  
         // a useful bootstrap option when you need the httpContext for bootstrap.
         BootStrapHttp(filterContext.HttpContext);
         base.OnActionExecuting(filterContext);
        }
        
    }
