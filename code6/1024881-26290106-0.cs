    public class MyModel
    {
        public int CustomId { get; set; }
        public string MyColumn1 { get; set; }
        public string MyColumn2 { get; set; }
        [Not Mapped]
        public string NotColumn1 { get; set; }
        [Not Mapped]
        public string NotColumn2 { get; set; }
    }
