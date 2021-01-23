    [Authorize]
    public class DefaultController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ...
        }
    }
