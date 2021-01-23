    // in some controller action
    var firstName  = ((CustomPrincipal)User).FirstName
    [Authorize]
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
