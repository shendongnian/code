    public override Task OnConnected()
    {
        // Get stock price 
    
       // Update client on new stocks
       Clients.All.UpdateStocks();
    }
