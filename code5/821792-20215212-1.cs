    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Redirect()
        {
            return this.RedirectToAction("Index");
        }
    }
