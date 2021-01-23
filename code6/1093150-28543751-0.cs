    [HttpPost]
    public ActionResult Edit()
    {
        return View(new RecurringPackViewModel(...));
    }
    [HttpPost]
    public ActionResult Create(RecurringPackInputModel model)
    {
        if (ModelState.IsValid)
        { 
           ... 
        }
    }
