    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        // GETL /Search/
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SendMail(MailMessage m)
        {
          return View();
        }
        [HttpPost]
        public ActionResult SendMail(MailMessage m)
        {
            return RedirectToAction("Contact");
        }
    }
