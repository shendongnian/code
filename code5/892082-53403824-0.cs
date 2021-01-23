        async void RunServerAsync()
        {
            var listner = new TcpListener(IPAddress.Any, 9999);
            listner.Start();
            try
            {
                while (true)
                    await Accept(await listner.AcceptTcpClientAsync());
            }
            finally { listner.Stop(); }
        }
        const int packet_length = 2;  // user defined packet length
        async Task Accept(TcpClient client)
        {
            await Task.Yield();
            try
            {
                using(client)
                using(NetworkStream n = client.GetStream())
                {
                    byte[] data = new byte[packet_length];
                    int bytesRead = 0;
                    int chunkSize = 1;
                    while (bytesRead < data.Length && chunkSize > 0)
                        bytesRead += chunkSize = 
                            await n.ReadAsync(data, bytesRead, data.Length - bytesRead);
                    // get data
                    string str = Encoding.Default.GetString(data);
                    Console.WriteLine("[server] received : {0}", str);
                    // To do
                    // ...
                    // send the result to client
                    string send_str = "server_send_test";
                    byte[] send_data = Encoding.ASCII.GetBytes(send_str);
                    await n.WriteAsync(send_data, 0, send_data.Length);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
