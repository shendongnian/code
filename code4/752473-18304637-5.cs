    public class HomeController : Controller 
    {
    	public ActionResult Index()
    	{
    		//getting info from database to variables
    		
    		SchoolModel schoolModel = new SchoolModel();
    		
    		schoolModel.SchoolName = //school retrieved from database, something like context.Schools.Name
    		schoolModel.Address = // something like context.Schools.Address
    		schoolModel.CreatedBy = // context.Users.Where(x => x.id == yourIdOrSomething)
    		return View(schoolModel);
    	}
    }
