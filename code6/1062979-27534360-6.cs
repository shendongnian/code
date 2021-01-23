    public class HomeController : Controller
    {
        private ETODbContext db = new ETODbContext();
        public ActionResult Index()
        {
            var model = new HomeViewModel {Events = db.Events.ToList()};
            return View(model);
        }
    }
