    public class BaseController : Controller
        {
           .....
           protected string SomeString { get; set; }
           ....
        }
    
    public class HomeController : BaseController
    {
       public ActionResult Index()
        {
            string theString = SomeString;
        }
    }
