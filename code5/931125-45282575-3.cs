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
            return connected;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
            return false;
        }
    }
    
    private async void Connection_Closed()
    {
        if(!IsFormClosed) // A global variable being set in "Form_closing" event of Form, check if form not closed explicitly to prevent a possible deadlock.
        {
            // specify a retry duration
            TimeSpan retryDuration = TimeSpan.FromSeconds(30);
              
            while (DateTime.UtcNow < DateTime.UtcNow.Add(retryDuration))
            {
                bool connected = await ConnectToSignalRServer(UserId);
                if (connected)
                    return;
            }
            Console.WriteLine("Connection closed")
        }
    }
