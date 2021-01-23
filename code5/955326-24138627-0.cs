    public object Get(DashboardRequest request)
    {
        // Should have waited here for the event to be triggered
        while(!_connected)
            System.Threading.Thread.Sleep(100);
        
        return new Dashboard { IsConnected = _isConnected };
    }
