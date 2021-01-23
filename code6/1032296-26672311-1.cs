    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult Upload(TestModel model, IEnumerable<HttpPostedFileBase> files)
        {
            return Json(new { files = files.ToList().Select(x => x.FileName), model = model });
        }		
    }
