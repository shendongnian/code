    public class Job
    {
            public string id { get; set; }
            public string position_title { get; set; }
            public string organization_name { get; set; }
            public string rate_interval_code { get; set; }
            public int minimum { get; set; }
            public int maximum { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public List<string> locations { get; set; }
            public string url { get; set; }
    }
