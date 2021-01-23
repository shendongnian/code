    private WebSocket _socket;
    public Initialize()
    {
        // initialize the client connection
        _socket = new WebSocket("ws://echo.websocket.org", origin: "http://example.com");
        // go through proxy for testing
        var proxy = new HttpConnectProxy(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888));
        _socket.Proxy = (SuperSocket.ClientEngine.IProxyConnector)proxy;
        // hook in all the event handling
        _socket.Opened += new EventHandler(OnSocketOpened);
        //_socket.Error += new EventHandler<ErrorEventArgs>(OnSocketError);
        //_socket.Closed += new EventHandler(OnSocketClosed);
        //_socket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(OnSocketMessageReceived);
        // open the connection if the url is defined
        if (!String.IsNullOrWhiteSpace(url))
            _socket.Open();
    }
    private void OnSocketOpened(object sender, EventArgs e)
    {
        // send the message
        _socket.Send("Hello World!");
    }
