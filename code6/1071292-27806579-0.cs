    public class ActivityQueryContainer
    {
        public Dictionary<string, string> Attributes { get; set; }
        public ActivityHistoryResult ActivityHistories { get; set; }
    }
    public class ActivityHistoryResult
    {
        public Activity[] Records { get; set; }
    }
    public class Activity
    {
        public DateTime ActivityDate { get; set; }
        public string Description { get; set; }
    }
