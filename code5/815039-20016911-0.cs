    public class HomeController : Controller
    {
          public ActionResult Index()
          {
            ViewBag.PageTitle = "Show this text into my MasterPage";
            return View();
          }
    }
