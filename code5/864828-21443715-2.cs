    public class HomeController : Controller
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public ActionResult Index(int siteNum)
        {
            var repository = RepositoryFactory.CreateRepositoryById(siteNum);
            // tada!
            return View();
        }
    }
