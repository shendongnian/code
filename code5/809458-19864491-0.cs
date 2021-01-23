    [HttpPost]
    public ActionResult Edit(PersonEditModel model)
    {
        // Validation round one, using attributes defined on your properties
        // The model binder checks for you if required fields are submitted, with correct length
        if(ModelState.IsValid)
        {
            // Validation round two, we push our model to the business layer
            var errorMessage = this.personService.Update(model);
            // some error has returned from the business layer
            if(!string.IsNullOrEmpty(errorMessage))
            {
                // Error is added to be displayed to the user
                ModelState.AddModelError(errorMessage);
            }
            else
            {
                // Update successfull
                return RedirectToAction("View", "Person", new { ID = model.ID});
            }
        }
        // Back to our form with current model values, as they're still in the ModelState
        return View();
    }
