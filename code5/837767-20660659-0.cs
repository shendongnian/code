    public class BaseController : Controller
    {
       protected string RedirectPath = string.Empty;
       protected bool DoRedirect = false;
       protected override void Initialize(RequestContext requestContext)
       {
          base.Initialize(requestContext);
          // Your logic to determine whether to redirect or not goes here. Bellow is an example...
          if (requestContext.HttpContext.User.IsInRole("RoleName"))
          {
             DoRedirect = true;
             RedirectPath = Url.Action("SomeAction", "SomeController");
          }
       }
       protected override void OnActionExecuting(ActionExecutingContext filterContext)
       {
           base.OnActionExecuting(filterContext);
           if (DoRedirect)
           {
              // Option 1: TRANSFER the request to another url
              filterContext.Result = new TransferResult(RedirectPath);
              // Option 2: REDIRECT the request to another url
              filterContext.Result = new RedirectResult(RedirectPath);
           }
       }
    }
