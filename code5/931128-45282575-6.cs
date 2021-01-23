    private async Task<bool> ConnectToSignalRServer()
    {
        bool connected = false;
        try
        {
            Connection = new HubConnection("server url");
            Hub = Connection.CreateHubProxy("MyHub");
            await Connection.Start();
             
            //See @Oran Dennison's comment on @KingOfHypocrites's answer
            if (Connection.State == ConnectionState.Connected)
            {
                connected = true;
                Connection.Closed += Connection_Closed;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return connected;
    }
    
    private async void Connection_Closed()
    {   // A global variable being set in "Form_closing" event 
        // of Form, check if form not closed explicitly to prevent a possible deadlock.
        if(!IsFormClosed) 
        {
            // specify a retry duration
            TimeSpan retryDuration = TimeSpan.FromSeconds(30);
            DateTime retryTill = DateTime.UtcNow.Add(retryDuration);
  
            while (DateTime.UtcNow < retryTill)
            {
                bool connected = await ConnectToSignalRServer();
                if (connected)
                    return;
            }
            Console.WriteLine("Connection closed")
        }
    }
