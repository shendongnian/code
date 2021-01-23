    public class Somefilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var controller = actionContext.ControllerContext.Controller;
                var someFilterattributes = actionContext.ActionDescriptor.GetCustomAttributes<Somefilter>()
                var otherAttributes = actionContext.ActionDescriptor.GetCustomAttributes<Other>()
            }
        }
