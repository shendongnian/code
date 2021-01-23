    public ActionResult Create()
    {
        // Assuming - First Time this ActioResult will be called.
        // After your other operations
        
        CustomModel model = new CustomModel();
    
        // Fill if any Data is needed
        return View(model);
    
        // OR - return new instance model here
        return View(new CustomModel());
    }
