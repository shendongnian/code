    private void Init()
    {
        _listener = new EasySocketListener();
        _listener.OnSocketAccept += Listener_OnSocketAccept;
        _listener.Start(port);
    }
    private void Listener_OnSocketAccept(object sender, SocketEventArgs e)
    {
        Debug.WriteLine( e.Socket.RemoteEndPoint );
    }
