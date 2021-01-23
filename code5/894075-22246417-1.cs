    public class MoviesController : Controller
	{
	    private ApplicationDbContext db = new ApplicationDbContext();
	    public ActionResult GetList() 
        {
	    	var model = from movie in db.Movies
	    			select new
	    			{
	    				ID = movie.ID,
	    				FirstName = movie.FirstName,
	    				SecondName = movie.SecondName,
	    				DOB = movie.DOB,
	    				Other = movie.Other
	    			}
	    	return View(model.ToList());
	    }
	    [HttpPost]
	    public ActionResult GetList(MovieModel model)
	    {
	        var data = db.Movies.ToList();
	        return View(data);
	    }
	}
