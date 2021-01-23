    [HttpPost]
    public ActionResult FirstForm(FirstFormModel model) {
        TempData["TempModelStorage"] = model;
        return RedirectToAction("SecondForm");
    }
    public ActionResult SecondForm() {
        var firstModel = TempData["TempModelStorage"] as FirstFormModel;
        // check for null, use as appropriate, etc.
    
        return View(...);
    }
