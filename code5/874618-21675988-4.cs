    public ActionResult Create()
    {
       var model = new FileUploadModel();
        
       return View(model);
        
    }
        
    [HttpPost]
    public ActionResult Create(FileUploadModel model)
    {
       var file = model.Files[0];
       return View(model);
    }
