     public class BaseController : Controller
       {
          protected override void OnActionExecuting(ActionExecutingContext filterContext)
          {
             CurrentUser = db.GetLoggedUserFromDatabase();  // to use in controller
             ViewBag.CurrentUser = CurrentUser;             // to use in views
          }
    
          public User CurrentUser { get; set; }   
       }
