        public async void Start(string ip)
        {
            label1.Text = "Begin";
            Stopwatch watch = new Stopwatch();
            while (true)
            {
                watch.Restart();
                using (TcpClient tcp = new TcpClient())
                {
                    //try to connect to a closed port
                    // First set a timeout value
                    tcp.SendTimeout = 1000;
                    try
                    {
                        await tcp.ConnectAsync("127.0.0.1", 1234);
                    }
                    catch (SocketException)
                    {
                        Debug.Assert(!tcp.Connected);
                    }
                    watch.Stop();
                    if (tcp.Connected)
                    {
                        label1.Text = watch.ElapsedMilliseconds.ToString() + " ms";
                    }
                    else
                    {
                        label1.Text = "Offline";
                    }
                }
                //wait 3secs for the next request
                await Task.Delay(3000);
            }
        }
    }
