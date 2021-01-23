    public ActionResult Index()
    {
        var viewModel = new IndexViewModel();
    
        viewModel.LogoUrl = // Get this from DB.
    
        return View(viewModel);
    }
    
