    public class LogOffController : Controller
    {
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
    
            HttpContext.User = null;
            Thread.CurrentPrincipal = null;
    
            return View();
        }
    }
