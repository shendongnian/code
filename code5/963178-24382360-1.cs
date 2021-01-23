        public abstract class ControllerBase : System.Web.Mvc.Controller
        {
               protected override void OnException(ExceptionContext filterContext)
                {
                    var ex= filterContext.Exception;
                    base.OnException(filterContext);
                }
    }
