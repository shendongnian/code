    [HttpPost]
    public ActionResult ProcessLogEntries(
        string txtSearchFor, string txtDateStart,
        string txtDateStop, string txtSource)
    {
        var model = new LogsResearchViewModel();
        // ...
        return PartialView("_GridPartial", model);
    }
