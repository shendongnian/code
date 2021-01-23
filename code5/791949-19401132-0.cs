    public class MyControllerBase : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            DoSomeSmartStuffWithException(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
