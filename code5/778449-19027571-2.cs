    public class UserValidationFilter : IActionFilter
    {
        private readonly IRepository repository;
    
        public UserValidationFilter(IRepository repository)
        {
            this.repository = repository;
        }
    
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //do something
        }
    
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //do something
        }      
    }
