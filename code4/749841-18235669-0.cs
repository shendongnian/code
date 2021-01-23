    public class ObjectiveVM
    {
        public DateTime DatePeriod { get; set; }
        public IList<ObList> obList { get; set; }
        public class ObList
        {
            public int ObjectiveId { get; set; }
            public int AnalystId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string AnalystName { get; set; }
            public bool Include { get; set; }
        }
    }
