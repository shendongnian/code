    [HttpGet]
    [Whitelist]
    public ActionResult Search()
    {
         return PartialView("_SearchFormPartial");
    }
    
    [HttpPost]
    [Whitelist]
    public ActionResult Search(string query)
    {
         return PartialView("_SearchResultsPartial");
    }
