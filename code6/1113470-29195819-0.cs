    namespace My.Sample
    {
        /// <summary>
        /// Settings controller used to maintain settings stuff
        /// </summary>
        public class SettingsController : Controller
        {
            [Authorize]
            public ActionResult EditSettings()
            {
    
                return View();
            }
    
            public ActionResult ViewSettings()
            {
                return View();
            }
        }
    }
