    public class MyController : Controller
    {
        [AuthorizeRoles(Role.Administrator, Role.Assistant)]
        public ActionResult AdminOrAssistant()
        {                       
            return View();
        }
    }
