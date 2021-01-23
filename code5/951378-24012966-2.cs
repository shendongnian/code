    namespace WebsiteName.Web.Controllers
     {
        public class PagesController : Controller
        {
             public ActionResult Index()
             {
                 ViewBag.isHome = true;
                 return View();
             }
     
             public ActionResult Contact()
             {
                 return View();
             }
        }
     }
