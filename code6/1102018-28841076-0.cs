    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SampleAction(int sampleValue)
        {
            Debug.WriteLine("SampleAction");
            Debug.WriteLine("\tsampleValue: " + sampleValue);
            return View("Index");
        }
    }
