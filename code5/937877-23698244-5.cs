        void Main()
        {
            var _networkClient = new NetworkClient();
            var sendCommandTask = SendCommand(_networkClient, "MyCommand");
            BasicAntwort reply = sendCommandTask.Result;
            reply.Dump();
        }
    
    
        private static bool HasBeginAndEnd(string[] message)
        {
            bool isValid = true;
        
            if (!message[0].StartsWith("<") || !message[0].EndsWith(">"))
                isValid = false;
        
            if (!message.Last().StartsWith("<END"))
                isValid = false;
        
            return isValid;
        }
        private static bool IsReplyMessage(string[] message)
        {
            return message.Length>0 && message[0].StartsWith("<REPLY ");
        }
        private static BasicAntwort ParseResponse(string[] message)
        {
            string header = message[0].Substring(7, message[0].Length - 8);
            return new BasicAntwort(message, header);
        }
    
        public IObservable<BasicAntwort> Responses(NetworkClient networkClient)
        {
            return Observable.FromEventPattern<MessageReceivedEventArgs>(
                    h => networkClient.MessageReceivedEvent += h,
                    h => networkClient.MessageReceivedEvent -= h)
                .Select(x => x.EventArgs.Content)
                .Where(HasBeginAndEnd)
                .Where(IsReplyMessage)
                .Select(ParseResponse);
        }   
    
        public Task<BasicAntwort> SendCommand(NetworkClient networkClient, string befehl)
        {
            //Subscribe first to avoid race condition.
            var result = Responses(networkClient)
                                .Where(reply=>reply.Header == befehl)
                                .Timeout(TimeSpan.FromSeconds(2))
                                .Take(1)
                                .ToTask();
            
            //Send command
            networkClient.SendMessage(befehl);
        
            return result;
        }   
    
    
    public class NetworkClient
    {
    public event EventHandler<MessageReceivedEventArgs> MessageReceivedEvent;
    public bool Connected { get; set; }
    public void SendMessage(string befehl)
    {
        var handle = MessageReceivedEvent;
        if(handle!=null){
        
            var message = new string[3]{"<REPLY " + befehl +">", "Some content", "<END>"};
            
            handle(this, new UserQuery.MessageReceivedEventArgs(){Content=message});
        }
    }
    }
    public class MessageReceivedEventArgs : EventArgs
    {
    public string[] Content { get; set; }
    }
    
    public class BasicAntwort
    {
        public BasicAntwort(string[] message, string header)
        {
            Header = header;
            Message = message;
        }
        
        public string Header { get; set; }
        public string[] Message { get; set; }
    }
