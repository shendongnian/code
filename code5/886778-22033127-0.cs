    TcpClientState[] ConnectAll(string host, int port)
    {
        var states = new List<TcpClientState>();
        for (int i = 1; i <= _maxTcpClients; i++)
        {
            TcpClientState tt = new TcpClientState(new TcpClient(), i);
            Func<Task> connectAsync = async () =>
            {
                try
                {
                    // note ConfigureAwait(false)
                    await tt.TcpClient.ConnectAsync(host, port).ConfigureAwait(false);
                    tt.SslStream = new SslStream(tt.TcpClient.GetStream(), false, Helper.ValidateServerCertificate, null);
                    await tt.SslStream.AuthenticateAsClientAsync(host);
                    // move here the code from SslAuthenticateCallback
                    // and so on ...  
                }
                catch (Exception ex)
                {
                    // you really want to do --_maxTcpClients ?
                    Interlocked.Decrement(ref _maxTcpClients);
                   
                    Debug.Print(ex.ToString());
                    throw; // re-throw or handle
                }
            };
            tt.ConnectionTask = connectAsync();
            states.Add(tt);
        }
        return states.ToArray();
    }
