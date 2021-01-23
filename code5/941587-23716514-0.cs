    public class Somefilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var controller = actionContext.ControllerContext.Controller;
                var attribute = actionContext.ActionDescriptor.GetCustomAttributes<Somefilter>()
                var otherattribute = actionContext.ActionDescriptor.GetCustomAttributes<Other>()
            }
        }
