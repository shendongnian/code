    public ActionResult Foo()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Foo(Foo model)
    {
        if (ModelState.IsValid)
        {
           // save to database or whatever
           return RedirectToAction("Bar");
        }
 
        return View(model);
    }
    public ActionResult Bar()
    {
        // retrieve model from database
        return View(model);
    }
