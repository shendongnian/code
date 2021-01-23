    public class HomeController : Controller
    {
        private ETODbContext db = new ETODbContext();
        public ActionResult Index()
        {
            var model = new HomveViewModel {Events = db.Events.ToList()};
            return View(model);
        }
    }
