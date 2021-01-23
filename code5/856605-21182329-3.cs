    [ValidateInput(false)]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Search(SearchViewModel searchViewModel)
    {
        return RedirectToAction(searchViewModel.SelectedCategory == 1 ? "Artists" : searchViewModel.SelectedCategory == 2 ? "Albums" : "Tracks", "Search");
    }
