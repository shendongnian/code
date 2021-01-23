    public class BaseReport
    {
        public ReportParams Params {get; set;}
        public BaseReport(ReportParams reportParams)
        {
            Params = reportParams;
        }
        // base implementation here
    }
    
    public class Report1 : BaseReport
    {
       // overrides here
    }
    var report = (BaseReport)Activator.CreateInstance(Type.GetType(type), new [] { parameters } );
