    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(DemoViewModel model)
    {
        int modelId = model.Id;
        if (!ModelState.IsValid) {
           //call the Edit action which displays the item .. or details. 
           //Not an ActionResult decorated as [HttpPost]!
           return RedirectToAction("EditGetAction", new { id = modelId });
        }
    
        ...
    
        return RedirectToAction("Details");
    }
