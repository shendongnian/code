        private async Task<long> Ping(string host, int port, int timeOut)
        {
            long elapsed = -1;
            Stopwatch watch = new Stopwatch();
            using (TcpClient tcp = new TcpClient())
            {
                try
                {
                    using (CancellationTokenSource cts = new CancellationTokenSource())
                    {
                        StartConnection(host, port, tcp, watch, cts);
                        await Task.Delay(timeOut, cts.Token);
                    }
                }
                catch {}
                finally
                {
                    if (tcp.Connected)
                    {
                        tcp.GetStream().Close();
                        elapsed = watch.ElapsedMilliseconds;
                    }
                    tcp.Close();
                }
            }
            return elapsed;
        }
        private async void StartConnection(string host, int port, TcpClient tcp, Stopwatch watch, CancellationTokenSource cts)
        {
            try
            {
                watch.Start();
                await tcp.ConnectAsync(host,port);
                watch.Stop();
                cts.Cancel();
            }
            catch {}
        }
