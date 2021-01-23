    public class CustomFilters : ActionFilterAttribute
    {
  
        [Dependency]
        public ICustomersService CustomersService { get; set; }
       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
