    [HttpGet]
    public ActionResult FirstStep()
    {
        return View("FirstStep", new Model());
    }
    
    [HttpPost]
    public ActionResult SecondStep(Model model)
    {
        return View("SecondStep", model);
    }
    
    [HttpPost]
    public ActionResult ThridStep(Model model)
    {
        return View("ThirdStep", model);
    }
    
    [HttpPost]
    public ActionResult Finish(Model model)
    {
        // DB Save ?
    }
