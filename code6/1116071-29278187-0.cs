    public class OverrideAuthorizeAttribute : AuthorizeAttribute, IOverrideFilter
    {
        public Type FiltersToOverride
        {
           get { return typeof(IAuthorizationFilter); }
        }
    }
    [OverrideAuthorize]
    public class AccountController : Controller
    {
        HttpContext.Current.Response.SuppressFormsAuthenticationRedirect = true;
        
        public ActionResult Profile()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    }
