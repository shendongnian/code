    public class MyActionAttribute : ActionFilterAttribute
    {
        private readonly string _conroller;
        private readonly string _action;
        private readonly string _id;
        public class MyActionAttribute : ActionFilterAttribute
        {
        public bool IsAllowed(string _conroller, string _action, string _id)
        {
            //write your logic to check if a user is allowed to perform the given action on this controller,action and id
            return UserisAllowed(_conroller, _action, _id);
        }
         public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var area =filterContext.RouteData.DataTokens["area"];
            if (!IsAllowed(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName, filterContext.RouteData.DataTokens["id"].ToString()))
            {
                //send user to somewhere saying you are not allow
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
