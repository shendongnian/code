    [HttpPost]
    public ActionResult Edit(PersonalData model)
    {
        if (ModelState.IsValid)
        {
            // Success
            return Redirect("NextAction");
        }
        return View(model);
    }
