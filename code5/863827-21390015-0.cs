    [Authorize]
    public class MyAccountController : Controller
    {
        public ActionResult Index()
        {
            var userData = System.Web.Security.Membership.GetUser();
            // note you could also get this from db using this.User.Identity.Name
            return View(userData);
        }
    }
