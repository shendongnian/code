    var obj = JsonConvert.DeserializeObject < Dictionary<string, Dictionary<string,RootObject>>>(json);
---
    public class Competitor
    {
        public string Team { get; set; }
        public string Win { get; set; }
    }
    public class CompetitorsClass
    {
        public int ActiveCompetitors { get; set; }
        public List<Competitor> Competitors { get; set; }
        public int TotalCompetitors { get; set; }
        public bool HasWinOdds { get; set; }
    }
    public class RootObject
    {
        public int EventID { get; set; }
        public int ParentEventID { get; set; }
        public string MainEvent { get; set; }
        public CompetitorsClass Competitors { get; set; }
        public string EventStatus { get; set; }
        public bool IsSuspended { get; set; }
        public bool AllowBets { get; set; }
    }
