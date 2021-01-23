        CancellationTokenSource _source;
        public void Start()
        {
            _source = new CancellationTokenSource();            
            Task.Factory.StartNew(() => Listen(1, _source.Token),_source.Token);
            Task.Factory.StartNew(() => Listen(2, _source.Token), _source.Token);
        }
        public void Stop()
        {
            _source.Cancel();
        }
        private async Task Listen(int port,CancellationToken token)
        {
            var tcp = new TcpClient();
            while(!token.IsCancellationRequested)
            {
                await tcp.ConnectAsync(ip, port);
                using (var stream=tcp.GetStream())
                {
                    ...
                    try
                    {
                        await stream.ReadAsync(buffer, offset, count, token);
                    }
                    catch (OperationCanceledException ex)
                    {
                        //Handle Cancellation
                    }
                    ...
                }
            }
        }
