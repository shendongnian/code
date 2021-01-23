    [HttpPost]
    public ActionResult Step1(Step1ViewModel model)
    {
        if (ModelState.IsValid)
        {
            Session["Step1"] = model;
            return RedirectToAction("Step2");
        }
        // errors
        return View(model);
    }
