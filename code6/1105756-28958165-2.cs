    public ActionResult Index()
    {
        var model = new List<Teams>();
        model.Add(new Teams { Name =  new List<string>(){"MU"}});
        model.Add(new Teams { Name =  new List<string>(){"Chelsea"} });
        ...
        return View(model);
    }
