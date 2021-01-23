    public class CustomAsyncTimeoutAttribute : AsyncTimeoutAttribute
    {
        public CustomAsyncTimeoutAttribute() : base(0)
        {}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            var managerContainer = filterContext.Controller as IAsyncManagerContainer;
            if (managerContainer == null)
                throw new InvalidOperationException("The operation has timed out.");
            managerContainer.AsyncManager.Timeout = //There you can get your timeout parameter from resourse (i.e. config file, database, etc);
            base.OnActionExecuting(filterContext);
        }
    }
