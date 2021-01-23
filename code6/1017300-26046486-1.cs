     public class HomeController : Controller //This is basically the same as ArticleCont.
        {
            public ActionResult Index()
            {
                ViewData["ArticleTitle"] = ConfigurationManager.AppSettings["ArticleTitle"];
                retrurn View();
            }
        }
