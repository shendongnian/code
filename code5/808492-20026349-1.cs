    public class GenericActionFilter : ActionFilterAttribute
    {
        public Type ModelType { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            IMediator mediator = null;
            if(filterContext.Controller is BaseController)
            {
                mediator = ((BaseController)filterContext.Controller).GetMediator();
                object paramValue = filterContext.ActionParameters["query"];
                var method = mediator.GetType().GetMethod("Request").MakeGenericMethod(new Type[] { ModelType });
                var model = method.Invoke(mediator, new object[] { paramValue });
                filterContext.Controller.ViewData.Model = model;
            }
        }
    
    }
