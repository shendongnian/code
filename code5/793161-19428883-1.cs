    public class ReportContent {
        public int ID { get; set; }
        public string Text { get; set; }
    }
    public class Report {
        ...
        public virtual ReportContent Content { get; set; }
        ...
    }
