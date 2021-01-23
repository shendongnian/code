    public ActionResult Index(string lastAction, string lastController)
    {
         .... // no students
    return RedirectToAction("Empty", "Navigation", new RouteValueDictionary(new { lastAction = "Index", lastController= "Student"}));
    }
