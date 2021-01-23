    public class FormController : Controller
    {
        public ActionResult Index(string MyType)
        {
            return RedirectToAction("Index", "MyProperController", new { MyType });
        }
    }
