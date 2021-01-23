    [HttpPost]
    public ActionResult Index(MyViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // some validation error occurred => redisplay the same form so that the user
            // can fix his errors
            return View(model);
        }
        // at this stage we know that the model is valid => let's attempt to process it
        string errorMessage;
        if (!DoSomethingWithTheModel(out errorMessage))
        {
            // some business transaction failed => redisplay the same view informing
            // the user that something went wrong with the processing of his request
            ModelState.AddModelError("", errorMessage);
            return View(model);
        }
        // Success => redirect
        return RedirectToAction("Success");
    }
