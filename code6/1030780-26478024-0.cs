        public class HomeController : Controller
        {
            MyDbContext data = new MyDbContext();
    
            public ActionResult Index()
            {
                var notes = data.Notes;
                return View(notes);
            }
            public ActionResult AddNewNote(Models.Note model)
            {
                data.Notes.Add(model);
                data.SaveChanges();
                var notes = data.Notes;
                return Redirect("~/");
            }
        }
