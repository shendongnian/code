    namespace Reports.Models.Common 
    {
        public class Report
        {
            public string ReportName { get; set; }
            public DateTime ReportDate { get; set; }
            public int NumberOfRows { get; set; }
            public int NumberOfErrors { get; set; }
            public string HasData { get; set; }
            public bool Remember {get;set;}
        }
    }
