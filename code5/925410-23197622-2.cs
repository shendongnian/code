    [HttpPost]
    public ActionResult Index(ModelClass mClass)
    {
    mClass.userName = "Hi!!, I am Sagar";
    return View(mClass);
    }
