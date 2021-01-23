    [HttpGet]
    public virtual ActionResult CreateEntity(int? officeCodeId)
    {            
        var model = new CreateViewModel();
        FillViewModel(model, officeCodeId);
        return View("Create", model);
    }
    [HttpPost]
    public virtual ActionResult CreateEntity(ViewModel model)
    {            
        if (model.IsValid) {
           // save...
           return RedirectToAction("EditEntity", newId!!!);
        } 
        
        return View("Create", model);
    }
