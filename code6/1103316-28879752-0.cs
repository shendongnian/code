        private TcpListener _listener;
        public void OnStart(CommandLineParser commandLine)
        {
            _listener = new TcpListener(IPAddress.Any, commandLine.Port);
            _listener.Start();
            Task.Run((Func<Task>) Listen);
        }
        private async Task Listen()
        {
            IMessageHandler handler = MessageHandler.Instance;
            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
                // Without the await here, the thread will run free
                var task = ProcessMessage(client);
            }
        }
        public void OnStop()
        {
            _listener.Stop();
        }
        public async Task ProcessMessage(TcpClient client)
        {
            try
            {
                using (var stream = client.GetStream())
                {
                    var message = await SimpleMessage.DecodeAsync(stream);
                    _handler.MessageReceived(message);
                }
            }
            catch (Exception e)
            {
                _handler.MessageError(e);
            }
            finally
            {
                (client as IDisposable).Dispose();
            }
        }
    }
