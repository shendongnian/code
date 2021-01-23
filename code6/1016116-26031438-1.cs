    private void bgWork1(object sender, DoWorkEventArgs e) 
    {
        IRCClient irc = new IRCClient();
        irc.OnConnected += new EventHandler(OnConnected);
        irc.OnChannelMessage += new IrcEventHandler(OnChanMsg);
        irc.OnQueryMessage += new IrcEventHandler(OnPriv);
        irc.OnJoin += new JoinEventHandler(OnJoined);
        irc.ActiveChannelSyncing = true; 
        irc.Start();
    }
    
    private void OnConnected(object sender, EventArgs e)
    {
        ...
    }
    //and other event handlers
