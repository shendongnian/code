    public ActionResult LoadGrid()
    {
        var model = new LogsResearchViewModel() { ... };
        return PartialView("_GridPartial", model);
    }
