    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SampleViewModel());
        }
    }    
