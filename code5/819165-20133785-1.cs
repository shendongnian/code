    [HttpPost]
    public ActionResult Edit(MyViewModel model, string button)
    {
        if (!ModelState.IsValid)
        {
            // The model isn't valid.  
            // Redisplay the form with the invalid model.
            return View(model);
        }
        // If we got here it means the model is valid.
    }
