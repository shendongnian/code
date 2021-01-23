    [HttpGet]
    public ActionResult Index(string productName) {
        // Lookup product from DB
    
        // do stuff
        var viewModel = ...;
        return View(viewModel);
    }
