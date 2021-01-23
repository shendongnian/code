    var hubConnection = new HubConnection("http://localhost:1235/");
    var hub = hubConnection.CreateHubProxy("moveShape");
    
    hub.On<string>("changeTransport", transportName =>
        Dispatcher.InvokeAsync(() =>
        {
            if (transportName == "longPolling")
            {
                hubConnection.Stop();
                hubConnection.Start(new LongPollingTransport());
            }
        }));
    
    await hubConnection.Start();
