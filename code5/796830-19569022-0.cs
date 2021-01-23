        public class ViewFileController : Controller
        {
           public ActionResult Index()
           {
               string stuff = "abcd";
               return Content(stuff);
           }
        }
