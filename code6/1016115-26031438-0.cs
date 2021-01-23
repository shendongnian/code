    class IRCClient
    {
        public event EventHandler OnConnected;
        public event IrcEventHandler OnChannelMessage;
        public event IrcEventHandler OnQueryMessage;
        public event JoinEventHandler OnJoin;
        public bool ActiveChannelSyncing { get; set; }
        ...    
    }
