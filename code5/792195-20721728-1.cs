    [ClaimsAuthorize(Roles = "AdvancedUsers")]
    public class SecurityController : Controller
    {
    
    	//Ignores the controller authorization and authorizes with Roles=Administrators
        [OverrideClaimsAuthorize(Roles = "Administrators")]
        public ActionResult AdministrativeTask()
        {
            return View();
        }
    
    	
    	//Runs both the controller and action authorization, so authorizes with Roles=Administrators AND Roles=AdvancedUsers
        [ClaimsAuthorize(Roles = "Administrators")]
        public ActionResult AdvancedAdministrativeTask()
        {
            return View();
        }
    	
    	//authorizes with controller authorization: Roles=AdvancedUsers
        public ActionResult SomeOtherAction()
        {
            return View();
        }
    }
