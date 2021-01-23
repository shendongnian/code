    [AuthorizeEx]
    public abstract partial class BaseController : Controller
    {
        public IOwinContext OwinContext
        {
            get { return HttpContext.GetOwinContext(); }
        }
        public new ClaimsPrincipal User
        {
            get { return base.User as ClaimsPrincipal; }
        }
        public WorkContext WorkContext { get; set; }
	}
