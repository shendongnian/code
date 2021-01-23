    public class MessageHeader
    {
        public string TypeName { get; set; }
    }
    
    public class Message
    {
        public MessageHeader Header { get; set; }
        public JToken Body { get; set; }
    }
