    [HttpGet]
    public ActionResult FirstStep()
    {
        return View(new FirstStepModel());
    }
    
    [HttpPost]
    public ActionResult SecondStep(FirstStepModel firstStepModel)
    {
        ViewBag.FirstStepModel = firstStepModel;
        return View(new SecondStepModel());
    }
    
    [HttpPost]
    public ActionResult ThridStep(FirstStepModel firstStepModel, SecondStepModel secondStepModel)
    {
        ViewBag.FirstStepModel = firstStepModel;
        ViewBag.SecondStepModel = secondStepModel;
        return View(new ThirdStepModel());
    }
    
    [HttpPost]
    public ActionResult FourthStep(FirstStepModel firstStepModel, SecondStepModel secondStepModel, ThirdStepModel thirdStepModel)
    {
        ViewBag.FirstStepModel = firstStepModel;
        ViewBag.SecondStepModel = secondStepModel;
        ViewBag.ThirdStepModel = thirdStepModel;
        return View(new FourthStepModel()));
    }
    
    [HttpPost]
    public ActionResult FifthStep(FirstStepModel firstStepModel, SecondStepModel secondStepModel, ThirdStepModel thirdStepModel, FourthStepModel fourthStepModel)
    {
        ViewBag.FirstStepModel = firstStepModel;
        ViewBag.SecondStepModel = secondStepModel;
        ViewBag.ThirdStepModel = thirdStepModel;
        ViewBag.FourthStepModel = fourthStepModel;
        return View(new FinalStepModel());
    }
    
    [HttpPost]
    public ActionRestul Finish(FirstStepModel firstStepModel, SecondStepModel secondStepModel, ThirdStepModel thirdStepModel, FourthStepModel fourthStepModel, FifthStepModel fifthStepModel)
    {
        // DB Save ?
    }
