    public class NewPageController : Controller
    {
        private SchoolContext db = new SchoolContext();
    
        public ActionResult ABC()
        {
    
            var Students = db.Students.Include("Enrollments.course"); //edit by OP
    
            return View(Students);
        }
     }
