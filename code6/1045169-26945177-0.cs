     public class HomeController : Controller
        {
            public ActionResult Index()
            {
                var model = new Product {Price = 9.99m};
                return View(model);
            }
        }
