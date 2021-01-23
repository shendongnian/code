     public class CustomExceptionAttribute : System.Web.Mvc.HandleErrorAttribute
        {
            public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
            {
                if (!filterContext.ExceptionHandled)
                {
                    filterContext.Controller.TempData.Add("Exception", filterContext.Exception);
                    filterContext.ExceptionHandled = true;
                }
            }
        }
    
        public class MyController : System.Web.Mvc.Controller
        {
            [CustomException]
            public ActionResult Test()
            {
                throw new InvalidOperationException();
            }
        }
