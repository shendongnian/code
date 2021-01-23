    protected override ActionResult GetSearchData(string filter)
    {
        IRemediationService svc = new RemediationService();
        var data = svc.SearchData(filter);
        try
        {
            return Content(data.ToString());
        }
        catch (Exception e)
        {
            return "Error";
        }
    }
