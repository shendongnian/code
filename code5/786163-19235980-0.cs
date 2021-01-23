    protected override JsonResult GetSearchData(string filter)
    {
        IRemediationService svc = new RemediationService();
        var data = svc.SearchData(filter);
        try
        {
            return new JsonResult()
                {
                    Data = data,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = Int32.MaxValue
                };
        }
        catch (Exception e)
        {
            return "Error";
        }
    }
