    public object Get(DashboardRequest request)
    {
        var dashboard = new DashboardAdapter();
        dashboard.OnConnected += OnConnection;
        return new Dashboard { IsConnected = _isConnected };
    }
