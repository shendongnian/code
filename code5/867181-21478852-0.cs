    public class LanguageCategoryController : Controller
    {
        MyDBContext db = new MyDBContext();
    
        public ActionResult Create()
        {
                ViewBag.LanguagesList = new SelectList(db.Languages, "ID", "Title");
                // or replace the above line with the other example above
                // if you want the empty "--select--" option
                return View();           
        }
    }
