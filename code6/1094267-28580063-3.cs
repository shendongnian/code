    [RoutePrefix("Test")]
    [Route("{action=Index}")]// Default Route
    public class HomeController : Controller
    {
            public ActionResult Index()
            {
                return View();
            }
            [Route("HelloAbout")] //Test/Users/About
            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
    
            [Route("~/NewTest/Contact")] //To override the Route "Test" with "NewTest".... NewTest/Contact
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }
            //[Route("home/{id?}")]
            public ActionResult Emp(int id)
            {
                return View();
            }
    }
