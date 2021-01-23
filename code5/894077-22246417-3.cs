    public class MoviesController : Controller
	{
	    private ApplicationDbContext db = new ApplicationDbContext();
	    public ActionResult GetList() 
        {
	    	var model = (from movie in db.Movies select movie).ToList();
	    	return View(model);
	    }
	    [HttpPost]
	    public ActionResult GetList(MovieModel model)
	    {
	        var data = db.Movies.ToList();
	        return View(data);
	    }
	}
