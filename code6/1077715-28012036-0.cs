    public class NewPageController : Controller
    {
        private SchoolContext db = new SchoolContext();
    
        public ActionResult ABC()
        {
    
            var Students = db.Students.Include("Enrollments");
    
            return View(Students);
        }
     }
