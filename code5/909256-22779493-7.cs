    public ActionResult Index()
    {
        ViewBag.NodeCount =  _graphClient.Cypher.Match("n").Return(n => n.Count()).Results.Single();
    
        return View();
    }
