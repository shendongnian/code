    class Message
    {
        public string message;
        public DateTime created;
        public Message(string message)
        {
            this.message = message;
            created = DateTime.Now;
        }
    }
