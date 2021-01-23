    public ActionResult GetTRAsString(string appID)
    {
        // Populate revisions
        var revisions = ...
        return PartialView(revisions);
    }
