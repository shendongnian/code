    public ActionResult KnowledgebaseSuggestions(String IncidentTags)
    {
        KnowledgeService KS = new KnowledgeService(db);
        var viewModel = KS.GetSuggestionsByTags(IncidentTags);
        return View(viewModel);
    }
