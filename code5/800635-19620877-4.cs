    void acceptCallback(IAsyncResult iar)
    {
        socket = listenSocket.EndAccept(iar);
        Dispatcher.Invoke(() =>
        {
            DialogResult = true;
            Close();
        });
    }
