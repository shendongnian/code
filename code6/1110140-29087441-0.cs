    [HttpGet]
    public ActionResult AdvancedSearch()
    {
            
            HttpContext currentContext = System.Web.HttpContext.Current;
            AdvancedSearchViewModel advancedSearchViewModel = (AdvancedSearchViewModel)Session["AdvancedSearchViewModel"];
            if (advancedSearchViewModel == null)
            {
                advancedSearchViewModel = new AdvancedSearchViewModel();
                AddAdvancedSearchLists(advancedSearchViewModel, currentContext);
            }
            return View(advancedSearchViewModel);
        }
