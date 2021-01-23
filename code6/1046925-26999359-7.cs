    public void Report(ReportWrapper pW)
    {
        Dictionary<string, object> pParameters = new Dictionary<string, object>();
        pParameters.Add("GroupIdents", pW.pGroupIdents);
        var reportService = new ReportService();     
        reportService.SetReportValues(pW.pReportName, pParameters);
    }
