    [ClaimsAuthorize(Roles = "AdvancedUsers")]
    public class SecurityController : Controller
    {
        [OverrideAuthorization()]
        [ClaimsAuthorize(Roles = "Administrators")]
        public ActionResult AdministrativeTask()
        {
            return View();
        }
        public ActionResult SomeOtherAction()
        {
            return View();
        }
    }
