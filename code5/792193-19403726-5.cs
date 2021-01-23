    [ClaimsAuthorize(Roles = "AdvancedUsers")]
    public class SecurityController : Controller
    {
        [ClaimsAuthorize(Roles = "Administrators")]
        public ActionResult AdministrativeTask()
        {
            return View();
        }
         [OverrideAuthorizeAttribute(Roles ="xxxx")] // This role will override controller                   
                                                      //level authorization 
        public ActionResult SomeOtherAction()
        {
            return View();
        }
    }
