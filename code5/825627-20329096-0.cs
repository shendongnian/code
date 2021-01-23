    public ActionResult Index(string Search)
    {
        var model = new SearchViewModel();
        model.SearchText = Search;
    
        return View("Search", model);
    }
