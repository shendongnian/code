    public class Message
    {
        (...)
        public DateTime DateTime { get { return DateTime.Parse(DateTimeStr); } }
        public String DateTimeStr { get; set; }
        
        (...)
    }
