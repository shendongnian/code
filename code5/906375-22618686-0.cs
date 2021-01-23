    public class FirstController : Controller
    {
        public ActionResult Index()
        {
            HttpContext.Session["Sample"] = "DATA";
            return View();
        }
    }
    public class SecondController : Controller
    {
        public ActionResult TestView()
        {
            string text = HttpContext.Current.Session["Sample"];
            return View();
        }
    }  
