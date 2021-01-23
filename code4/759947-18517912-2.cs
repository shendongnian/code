    public ActionResult Edit(ContactEditModel model)
    {
         return View(model);
    }
    [HttpPost]
    public ActionResult Edit(ContactEditModel model)
    {
         // Implementation
         // model will have all updated values from UI
         return View(user);
    } 
