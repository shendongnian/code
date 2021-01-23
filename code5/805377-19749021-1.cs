    [HttpGet]
    public ActionResult SampleController()
    {
        return View();
    }
    [HttpPost]
    public ActionResult SampleController(SampleModel model)
    {
        //put code here to send to database
        return View(model);
    }
