    private async Task<bool> ConnectToSignalRServer(string musteriNo)
    {
        bool connected = false;
        try
        {
            Connection = new HubConnection("server url");
            Hub = Connection.CreateHubProxy("MyHub");
            await Connection.Start();
    
            if (Connection.State == ConnectionState.Connected)
            {
                connected = true;
                Connection.Closed += Connection_Closed;
            }
            return connected;
        }
        catch (Exception ex)
        {
            using (StreamWriter sw = File.AppendText(@"C:\log.txt"))
            {
                sw.WriteLine(string.Format(@"[{0}]: Error, ConnectToSignalRServer, Exception: {1} ", 
                DateTime.UtcNow.ToString("yyyyMMdd hh:mm:ss.f"), ex.Message));
            }
            return false;
        }
    }
    
    private async void Connection_Closed()
    {
        // specify a retry duration
        TimeSpan retryDuration = TimeSpan.FromSeconds(30);
              
        while (DateTime.UtcNow < DateTime.UtcNow.Add(retryDuration))
        {
            bool connected = await ConnectToSignalRServer(UserId);
            if (connected)
                return;
        }
        using (StreamWriter sw = File.AppendText(@"C:\log.txt"))
        {
            TextWriter.Synchronized(sw).WriteLine(string.Format(@"[{0}]: Connection Closed", DateTime.UtcNow.ToString("hh:mm:ss.f")));
        }
    }
