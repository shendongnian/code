    public ActionResult Index()
    {
        var model = tm.ToList();
        List<stirng> names = new List<string>;
        names.Add("Manchester United");
        names.Add("Chelsea");
        names.Add("Manchester City");
        names.Add("Arsenal");
        names.Add("Liverpool");
        names.Add("Tottenham");
        names.Add(new Team {Name =  names });
        ...
        return View(model);
    }
