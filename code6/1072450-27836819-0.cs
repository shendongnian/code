    [HttpPost]
    public ActionResult Index(TestModel testModel)
    {
        ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
        testModel.Username = string.Empty;
        ModelState.Clear();
        return View(testModel);
    }
