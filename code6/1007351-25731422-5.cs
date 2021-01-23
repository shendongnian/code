    public abstract class ControllerBase : Controller
    {
        public new UserPrincipal User
        {
            get { return HttpContext.User as UserPrincipal; }
        }
    }
