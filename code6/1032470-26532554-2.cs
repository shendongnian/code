    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Story story1 = new Story("Test title", "Test author");
            return View(story1);
        }
    }
    <h1>@Model.Title</h1>
