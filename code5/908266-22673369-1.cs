    public ActionResult MyAction()
    {
        var model = new List<ModelB>
        {
            new ModelB{Age = 2, Name = "Bob"},
            new ModelB{Age = 7, Name = "Sam"},
        };
        return View(model);
    }
    [HttpPost]
    public ActionResult MyAction(List<ModelB> model)
    {
        //whatever
    }
