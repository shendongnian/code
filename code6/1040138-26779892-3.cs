    public class MyIndexViewModel
    {
    	public List<CountUser> CountUsers { get; set; }
    	public List<Team> Teams { get; set; }
    }
    public ActionResult Index(string sortOrder)
    {
    	var userCount = db.CountUser();
    	
    	ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
    	
    	var teams = from t in db.Teams
    				select t;
    				
    	switch ((string)ViewBag.NameSortParm)
    	{
    		case "name_desc":
    			teams = teams.OrderByDescending(t => t.TeamName);
    			break;
    
    		default:
    			teams = teams.OrderBy(t => t.TeamName);
    			break;
    	}
    
    	return View(new MyIndexViewModel { CountUsers = userCount.ToList(), Teams = teams.ToList() });
    }
