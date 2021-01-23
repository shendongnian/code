    public class LogUserActionTimeFilter : IActionFilter
    {
        private readonly IUserAuthService userAuthService;
        public LogAdminRequestFilter()
            : this(new UserAuthService())
        {
        }
        public LogAdminRequestFilter(IUserAuthService userAuthService)
        {
            this.userAuthService = userAuthService;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.userAuthService.SaveCurrentTimeAsLastActionTime(
                filterContext.HttpContext.User.Identity.Name);
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
