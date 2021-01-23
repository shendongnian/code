    [HttpPost]
    public ActionResult Index(ModelClass model)
    {
    model.userName = "Hi!!, I am Sagar";
    return View(model);
    }
