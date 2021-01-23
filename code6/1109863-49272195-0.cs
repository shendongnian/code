    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAsyncTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }
            var managerContainer = filterContext.Controller as IAsyncManagerContainer;
            if (managerContainer == null)
            {
                throw new InvalidOperationException("CustomAsyncTimeout Action Filter failed");
            }
            
            var duration = GetYouDurationAsYouWish();
            if (duration < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(duration));
            }
            managerContainer.AsyncManager.Timeout = duration;
            base.OnActionExecuting(filterContext);
        }
    }
