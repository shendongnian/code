    public ActionResult PortfolioCollection(string id)
    {
        const string folder = @"~/Content/images/portfolio/";
        var files = Directory
            .EnumerateFiles(Server.MapPath(folder + id))
            .Select(Path.GetFileName);
        return View(files);
    }
