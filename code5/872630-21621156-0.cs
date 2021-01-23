    protected ActionResult Index()
    {
    	ViewBag.ErrorMessage = "";
    
    	//some code
    	try
    	{
    		//more code
    	} catch(Exception ex)
    	{
    		ViewBag.ErrorMessage = "alertError('" + ex.Message + "');";
    	}
        return View();
    }
