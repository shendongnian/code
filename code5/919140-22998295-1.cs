    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class HanlleyDisable : Attribute { }
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool disabled = filterContext.ActionDescriptor.IsDefined(typeof(HanlleyDisable ), true) ||
                            filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(HanlleyDisable), true);
            if (disabled)
                return;    
            // action filter logic here...
        }
    }
    class FooController  {  
       
        [HanlleyDisable]
        MyMethod() { ... } 
    }
