    public class MyViewModel {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
    
    public ActionResult Index()
    {
        var model = new MyViewModel {
            Movies = db.Movies.ToList(),
            Students = db.Students.ToList()
        }
        return View(model);
    }
