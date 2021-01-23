    var hubConnection = new HubConnection("http://localhost:1235/");
    var hub = hubConnection.CreateHubProxy("moveShape");
    
    hub.On<string>("changeTransport", transportName =>
        Dispatcher.InvokeAsync(() =>
        {
            this.Title = transportName;
            hubConnection.Stop();
            if (transportName == "longPolling")
            {
                hubConnection.Start(new LongPollingTransport());
            }
        }));
    
    await hubConnection.Start();
