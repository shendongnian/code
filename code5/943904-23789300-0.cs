    public ActionResult GetIssueList(string code)
    {
    	IEnumerable<Project> projects =
    		new ProjectManager()
            .SelectAllProjects()
    		.Cast<Project>();
    	
    	//this is replacement for Where call.
        //Debug breakpoint here step by step and look at the CustomerCode values
        //to find out why they are all added.
    	List<Project> filtered = new List<Project>();
    	foreach(Project p in projects)
    	{
    		if(p.CustomerCode == code)
    			filtered.Add(p);
    	}
    			
        return Json(filtered);
    }
