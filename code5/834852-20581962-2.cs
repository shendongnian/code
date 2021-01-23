    public ActionResult SearchResults(string input)
    {
        ViewBag.Title = "Search";
        ViewBag.Message = "Your search returned the following match(es).";
        var results = Model.ModelController.UniversalSearch(input);
        var model = new SearchResultModel {
           Movies = results.MovieListForUser,
           People = results.PersonListForUser
        };
        return View(model);
    }
