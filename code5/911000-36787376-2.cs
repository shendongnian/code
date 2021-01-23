    public class ReportsController : Telerik.Reporting.Services.WebApi.ReportsControllerBase
    {
         public ReportsController()
         {
             var tempFolder =  ConfigurationManager.AppSettings["WebsiteTemporaryFolder]; // We set this in web.config
             this.ReportServiceConfiguration = new Telerik.Reporting.Services.ReportServiceConfiguration
             {
                  HostAppId = "TelerikReportsService",
                  ReportResolver = new ReportResolver(), // Custom class, not included in this example
                  Storage = new Telerik.Reporting.Cache.File.FileStorage(tempFolder)
             };
         }
    }
