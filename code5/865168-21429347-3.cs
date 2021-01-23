    [HttpPost]
    public ActionResult DetailsReport(ReportModel model)
    {
        ...
        var startDate = model.StartDate.ToString();
        var startEnd = model.StartEnd.ToString();
        ReportParameter param0 = new ReportParameter("dtStartDate", startDate);
        ReportParameter param1 = new ReportParameter("dtStartEnd", startEnd);
        ...
    }
