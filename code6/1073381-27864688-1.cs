    [HttpGet]
    public ActionResult Summary()
    {
        return View(new List<myProj.Models.myModel>());
    }
    [HttpPost]
    public ActionResult Summary(List<myProj.Models.myModel> input)
    {
        return View(input);
    }
