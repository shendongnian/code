        private async Task Listen(int port,CancellationToken token)
        {
            var tcp = new TcpClient();
            while(!token.IsCancellationRequested)
            {
                await tcp.ConnectAsync(ip, port);
                using (var stream=tcp.GetStream())
                {
                    ///...
                    await stream.ReadAsync(buffer, offset, count, token)
                        .ContinueWith(t =>
                        {
                            if (t.IsCanceled)
                            {
                                //Do some cleanup?
                            }
                            else
                            {
                                //Process the buffer and send notifications
                            }
                        });
                    ///...
                }
            }
        }
