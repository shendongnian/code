        public class RSSSController : Controller
    {
        public ActionResult Index(string searchString)
        {
            return View(Search.Models.RsssReader.GetMultipleFeeds(searchString));
        }
