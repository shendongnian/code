    public class MessageData
    {
        public Guid ID { get; set; }
        public string Severity { get; set; }
        public string Description { get; set; }
        public string ClientID { get; set; }
        public string Specialty { get; set; }
        public DateTime IssuedDate { get; set; }
        public ObservableCollection<MessageData> Messages { get; set; }
    }
