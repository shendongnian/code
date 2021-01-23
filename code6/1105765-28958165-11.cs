    public ActionResult Index()
    {
        var model = new List<Team>();
        model.Add(new Team { Name = "MU"});
        model.Add(new Team { Name = "Chelsea"});
        ...
        return View(model);
    }
