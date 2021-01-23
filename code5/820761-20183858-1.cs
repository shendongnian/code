    [HttpPost]
    public ActionResult YourAction(FormCollection form,YourViewModel model)
    {
        ViewBag.SelectedItem = form["Condition2"];
         ///
        return View(model);
    }
