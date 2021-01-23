    class ValidationController : Controller {
    
        private IDbContext db = ...;
        public ActionResult UniqueTitle(String title) {
            var item = db.Movies.FirstOrDefault(m => m.Title.Equals(title));
            return Json(item == null, JsonRequestBehavior.AllowGet);
        }
    }
