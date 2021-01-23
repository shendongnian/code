    public ActionResult Create()
    {
        var data = new ServiceForm();
        data.Categories = new SelectList({"1", "category1"}, {"2", "category2"});
        return View(data);
    }
    [HttpPost]
    public ActionResult Create(ServiceForm form)
    {
         // validate the input and save
    }
