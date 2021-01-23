         //[ClaimsAuthorize(Roles = "AdvancedUsers")]
         public class SecurityController : Controller
         {
            {
            [ClaimsAuthorize(Roles ="Administrators", "Role2","Role3")]
            public ActionResult AdministrativeTask()
            {
                return View();
            }
        }
