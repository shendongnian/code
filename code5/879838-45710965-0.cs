        public async Task Run(CancellationToken cancellationToken)
        {
            TcpListener listener = new TcpListener(address, port);
            listener.Start();
            cancellationToken.Register(listener.Stop);
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    var clientTask = protocol.HandleClient(client, cancellationToken)
                        .ContinueWith((antecedent) => client.Dispose())
                        .ContinueWith((antecedent)=> logger.LogInformation("Client disposed."));
                }
                catch (ObjectDisposedException) when (cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation("TcpListener stopped listening because cancellation was requested.");
                }
                catch (Exception ex)
                {
                    logger.LogError(new EventId(), ex, $"Error handling client: {ex.Message}");
                }
            }
        }
