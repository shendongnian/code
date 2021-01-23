    public class BlogController : Controller
    {
        public ActionResult Details(string blogCategory, string blogTitle)
        {
            return Content(string.Format("category: {0}, title: {1}", blogCategory, blogTitle));
        }
    }
