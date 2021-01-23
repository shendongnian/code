    public ActionResult TheAction(AssessorsViewModel model)
    {
        if (model.Assessors == null
            || model.Assessors.Count < 3
            || model.Assessors.Count > 7)
        {
            ModelState.AddModelError("Assessors", "Please enter note less than 3 and not more than 7 assessors.");
            return View(model);
        }
        ...
    }
