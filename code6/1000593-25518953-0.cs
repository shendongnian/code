      // Get:
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Students()
    {
        // do some stuff
        return View();
    }
    
    // Post:
    [ActionName("Students")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Students_Post()
    {
        // do some stuff
        return View();
    }
