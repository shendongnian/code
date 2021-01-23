    public ActionResult Generate()
    {
        return View(new GroupViewModel());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Generate(GroupViewModel gvm)
    {
        var subjects= gvm.Subjects; // <== selected subjects are here
        return View();
    }
