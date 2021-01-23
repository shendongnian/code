    public class TestCustomAttr : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ActionInfo = filterContext.ActionDescriptor;
            var pars = ActionInfo.GetParameters();
            foreach (var p in pars)
            {
                
               var type = p.ParameterType; //get type expected
            }
          
        }
    }
