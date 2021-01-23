    public abstract class BaseController : Controller
    {
        public new HttpContextBase HttpContext { get; private set; }
        protected virtual new ICustomPrincipal User
        {
            get { return HttpContext.User as ICustomPrincipal; }
        }
    }
