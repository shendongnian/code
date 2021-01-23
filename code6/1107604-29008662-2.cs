    public ActionResult SaveData(Model model)
    {
    	if (ModelState.IsValid)
    	{
    		// update here
    		// then redirect to view
    		return RedirectToAction("View", new { id = model.ID });
    	}
    	return View(model);
    }
