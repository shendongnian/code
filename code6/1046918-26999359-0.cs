    public class ReportService()
    {
       public void SetReportValues(string pReportName, Dictionary<string, object> pParameters)
       {
          Session["ReportName"] = pReportName;
          Session["ReportParameters"] = pParameters;
       }
    }
