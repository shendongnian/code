    [HttpPost]
    public ActionResult YourActionName(YourModel model)
    {
        model.Facilities = ..; // set again
        return View(model);
    }
