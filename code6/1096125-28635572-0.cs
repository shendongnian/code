    [HttpGet]
    public ActionResult SomeForm(int id)
    {
        var model = FindModelById(id);
        if(model != null)
           return View(model);
        return View(getModelFromSomewhere());
    }
