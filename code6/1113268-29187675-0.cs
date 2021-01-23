    namespace Project.Controllers
    {
        public class HomeController : Controller
        {
            public ContentResult ServePureHtml()
            {
                string htmlData = System.IO.File.ReadAllText(@"W:\1.html");
                return Content(htmlData, "text/html");
            }
        }
    }
