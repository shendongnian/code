    public class TestController : Controller
    {
        // GET: Test
           [Authorize] // just redirects back to login page if you call create action. 
        public ActionResult Index()
        {
            return View();
        }
     
        // GET: Test/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index"); 
        }
