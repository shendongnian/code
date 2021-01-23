    public class AppController: Controller
     {
        public IActionResult Index()
        {
           ViewBag.Title = "Home Page";
           return View();
        }
    }
