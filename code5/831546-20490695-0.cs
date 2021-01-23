    [HttpPost]
    public ActionResult Index(TestModel model)
    {
        ModelState.Clear(); 
        model.Name = "After post";
        return View("Index", model);
    }
