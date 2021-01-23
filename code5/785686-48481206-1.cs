    public async Task ListenAsync(IPEndPoint endPoint, CancellationToken cancellationToken)
    {
        TcpListener listener = new TcpListener(endPoint);
        listener.Start();
        
        // Stop() typically makes AcceptSocketAsync() throw an ObjectDisposedException.
        cancellationToken.Register(() => listener.Stop());
        // Continually listen for new clients connecting.
        try
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Socket clientSocket = await listener.AcceptSocketAsync();
            }
        }
        catch (OperationCanceledException) { throw; }
        catch (Exception) { cancellationToken.ThrowIfCancellationRequested(); }
    }
