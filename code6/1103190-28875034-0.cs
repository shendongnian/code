    public class MvcApplication : System.Web.HttpApplication
            {
                public string SomeString { get; set; }
            }
            
            
            public class HomeController : Controller
            {
                public ActionResult Index()
                {
        
        MvcApplication mvc = new MvcApplication();
                    mvc.SomeString = "Test1";
                }
            }
