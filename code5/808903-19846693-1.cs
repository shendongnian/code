    public ActionResult SomeView(SomeViewModel model)
    {
        if (ModelState.IsValid)
        {
           // Model is valid so redirect to another action
           // to indicate success.
           return RedirectToAction("Success");
        }
        // This redisplays the form with any errors in the ModelState
        // collection that have been added by the model binder.
        return View(model);
    }
