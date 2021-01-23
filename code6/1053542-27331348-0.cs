    namespace YourReportNamespace
    {
        public class ReportClass
        {
            public List<string> TestReportData()
            {
                return new List<string>();
            }
            public static List<string> StaticTestReportData()
            {
                return new List<string>();
            }
        }
    
    
        public class ReportWithFieldsClass 
        {
            private List<string> Data = new List<string>();
            
            public List<string> TestReportData()
            {
                return Data;
            }
    
            public List<string> TestReportData2()
            {
                return Data;
            }
    
            public static List<string> StaticTestReportData()
            {
                return new List<string>();
            }
        }
    
        public static class ReportWithFieldsStaticClass //This class will not appear
        {
            private static List<string> Data = new List<string>();
    
            public static List<string> StaticTestReportDataFromField()
            {
                return Data;
            }
            public static List<string> StaticTestReportData()
            {
                return new List<string>();
            }
        }
    }
