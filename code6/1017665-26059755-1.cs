    public class HomeController : Controller
    {
        public ActionResult GridView()
        {
            return this.View();
        }
    
        public JsonResult Getjsondata()
        {
            var Contacts = db.Contacts.ToList();
            return Json(Contacts, JsonRequestBehavior.AllowGet);
        }
    }
