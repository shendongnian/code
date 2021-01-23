        public async void Serve()
        {
            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                Task.Factory.StartNew(() => HandleClient(client), TaskCreationOptions.LongRunning);
            }
        }
