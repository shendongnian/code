    public ActionResult Index(string sortOrder)
    {
    	var userCount = db.CountUser();
    	
    	ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : sortOrder;
    	
    	var teams = from t in db.Teams
    				select t;
    				
    	switch (ViewBag.NameSortParm)
    	{
    		case "name_desc":
    			teams = teams.OrderByDescending(t => t.TeamName);
    			break;
    
    		default:
    			teams = teams.OrderBy(t => t.TeamName);
    			break;
    	}
    	
    	ViewBag.Teams = teams.ToList();
    
    	return View(userCount.ToList());
    }
