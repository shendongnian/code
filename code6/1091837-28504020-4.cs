    public ActionResult Index()
    {
        var model = new Model();
        model.Items = GetItems();
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(Model model)
    {
        if(ModelState.IsValid)
        {
           //Update stuff
           //return to a different page or whatever needs to be done 
           //after a successful update
        } 
    
        // If model is not valid...
        model.Items = GetItems();
        return View(model);
    }
    
    
