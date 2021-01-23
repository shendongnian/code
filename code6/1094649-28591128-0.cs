    public class VoidActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var retType = actionContext.ActionDescriptor.ReturnType;
            if (retType == typeof(void) || retType == null)
            {
                actionContext.ActionDescriptor = new MyVoidActionDescriptor(actionContext.ActionDescriptor);
            }
            base.OnActionExecuting(actionContext);
        }
    }
