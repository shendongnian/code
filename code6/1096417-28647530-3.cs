    public class LanguageController : Controller
    {
        [HttpPost]
        public ActionResult ChangeLanguage(string lang)
        {
            // change language, persist setting with cookie, session etc.
    
            // redirect to the page the user came from
            Redirect(Request.UrlReferrer);
        }
    }
