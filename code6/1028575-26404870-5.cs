    public ActionResult Index()
    {
        using (var data = new PortfolioDBContext())
        {
            var model = data.Portfolio.ToList(); // ToList so the controller queries the DB
            // does "model" have anything in it here?
            return View(model);
        }
    }
