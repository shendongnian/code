    public class Survey
    {
        public string title { get; set; }
        public int id { get; set; }
    }
    public class RootObject
    {
        public List<Survey> surveys { get; set; }
    }
