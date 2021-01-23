    public ActionResult Index()
    {
        var model = tm.ToList();
        model.Add(new Team {Name = "Manchester United" });
        model.Add(new Team {Name = "Chelsea" }));
        ...
        return View(model);
    }
