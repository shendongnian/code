    public Message
    {
        public string JsonObject { get; set; }
    
        public string MessageTypeName { get; set; }
    
        public Type MessageType { get { return Type.GetType(MessageTypeName); } }
    }
