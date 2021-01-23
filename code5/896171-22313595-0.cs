    public class HomeController : Controller {
        private RegionalSalesManConnection _db;
        public HomeController() {
            _db = new RegionalSalesManConnection();
        }
        public ViewResult Index() {
           var model = db.RegionalManagers.ToList();
           return View(model);
        }
    }
