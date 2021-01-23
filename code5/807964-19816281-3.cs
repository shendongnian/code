    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Results(string searchCriteria)
        {
            var model = // ... filter using searchCriteria
            return View(model);
        }
    }
