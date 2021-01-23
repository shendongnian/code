    public class DemoController : Controller
    {
        private MainDatabaseEntities db = new MainDatabaseEntities();
    
        public ActionResult Details(int id)
        {
            return View(db.ANIME.Find(id));
        }
    
        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
