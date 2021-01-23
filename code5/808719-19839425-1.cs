    public ActionResult Index()
    {
    	var viewModel = new MyViewModel
    	{
    		Added = ...,
    		Removed = ...
    	};
    	return View(viewModel);
    }
    
