    class ClientSocket 
    {
     public ClientSocket(ISynchronizeInvoke syncSource)
     {
          _syncSource = syncSource;
     }
     private ISynchronizeInvoke _syncSource;
     public delegate void ConnectHandler(object sender, EventArgs e);
     public event ConnectHandler ConnectEvent = delegate { };
     protected void OnConnectEvent(EventArgs e) {
        ConnectHandler ev = ConnectEvent;
        //This may not be the exact right syntax.
        _syncSource.BeginInvoke(ev, this, e);
     }
    }
