    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var viewModel = new MovieViewModel
            {
                Genre = "2"
            };
    
            return View(viewModel);
        }
    }
