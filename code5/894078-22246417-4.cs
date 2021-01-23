    public class MoviesController : Controller
	{
	    private ApplicationDbContext db = new ApplicationDbContext();
	    public ActionResult GetList() 
        {
	    	var model = db.Movies.ToList();
	    	return View(model);
	    }
	    [HttpPost]
	    public ActionResult GetList(MovieModel model)
	    {
	        var data = db.Movies.ToList();
	        return View(data);
	    }
	}
