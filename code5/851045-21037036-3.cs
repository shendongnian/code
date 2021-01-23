    [Export("Plugin1", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Plugin1Controller : Controller
    {
        //
        // GET: /Plugin1/
        public ActionResult Index()
        {
            return View();
        }
    }
