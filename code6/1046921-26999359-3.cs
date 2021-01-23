    public class ReportService()
    {
       public void SetReportValues(string pReportName, Dictionary<string, object> pParameters)
       {
          HttpContext.Current.Session["ReportName"] = pReportName;
          HttpContext.Current.Session["ReportParameters"] = pParameters;
       }
    }
