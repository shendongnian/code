    public class ReportsModel
    {
        public List<ReportModel> ReportsList { get; set; }
    }
    public class ReportModel
    {
        public Report Report { get; set; }
        public bool IsChecked { get; set; }
    }
    public class Report
    {
        public string ReportName { get; set; }
        public DateTime ReportDate { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfErrors { get; set; }
        public string HasData { get; set; }
    }
