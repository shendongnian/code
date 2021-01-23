    public class Message
    {
        [DataMember]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; internal set; }
    
        [DataMember]
        public string MessageBody { get; internal set; }
    
        internal Message() { }
    }
    
    public static class MessageFactory
    {
        public static Message Create()
        {
            return new Message();
        }
    }
