    public class HoursReport
    {
        public List<Client> MyClients { get; set; }
        public String Start {get; set;}
        public String End {get; set;}
        public String Key {get; set;}
        public String DontIncludeMe {get; set;}
    }
    public class HoursReportResponse
    {
       [JsonProperty(PropertyName="start")]
       public string Start {get; set;}
       [JsonProperty(PropertyName="end")]
       public string End {get; set;}
    }
    public class HoursReportMapper
    {
        public HoursReportResponse Map(HoursReport hoursReport)
        {
            return new HoursReportResponse
            {
                Start = hoursReport.Start,
                End = hoursReport.End
            };
        }
    }
