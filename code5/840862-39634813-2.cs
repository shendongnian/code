    public class SettingsUsersController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/SettingsUsers/Index.cshtml", db.YourDBName.ToList());
        }
    }
