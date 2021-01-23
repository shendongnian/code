    public class BaseController : Controller
    {
         protected BaseController(common DI)
         {
         }
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
          // some logic after action method get executed      
            base.OnActionExecuted(filterContext);
        }
         
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // some login before any action method get executed
           string actionName = filterContext.RouteData.Values["action"].ToString(); // Index.en-US
            filterContext.Controller.ViewBag.SomeFlage= true;
        }
      // If Project is in MVC 4 - AsyncContoller support, 
      //below method is called before any action method get called, Action Invoker
       protected override IActionInvoker CreateActionInvoker()
        {       
            return base.CreateActionInvoker();
        }
    }
    
    
