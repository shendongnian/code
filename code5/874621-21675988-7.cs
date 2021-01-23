    public ActionResult Create()
    {
        var model = new ModelToCreate();
    
        return View(model);
    
    }
    
    [HttpPost]
    public ActionResult Create(ModelToCreate model)
    {
       var file = model.Files.Files[0];
       return View(model);
    }
