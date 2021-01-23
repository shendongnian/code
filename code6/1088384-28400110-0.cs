    public class FeatureController : Controller
    {
        [Authorize(Roles = "Feature1")]
        public ActionResult Feature1()
        {
            // Implement feature here...
            return View();
        }
        [Authorize(Roles = "Feature1")]
        [HttpPost]
        public ActionResult Feature1(Model model)
        {
            // Implement feature here...
            return View();
        }
        [Authorize(Roles = "Feature2")]
        public ActionResult Feature2()
        {
            // Implement feature here...
            return View();
        }
        // Other features...
    }
