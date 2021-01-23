    public class MoviesController : Controller
    {
    
      private ApplicationDbContext db = new ApplicationDbContext();
    
      public ActionResult GetList() 
      {
        var Movies = (from movie in db.Movies select movie).ToList();
        return View(Movies);
      }
    
      [HttpPost]
      public ActionResult GetList(MovieModel model)
      {
       var data = db.Movies.ToList();
        return View(data);
      }
