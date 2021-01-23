    LiveConnectClient client;
    var auth = new LiveAuthClient("YourGeneratedKey");
    var result = await auth.InitializeAsync(new [] {"wl.basic", "wl.signin", "wl.skydrive_update" });
    // If you're not connected yet, that means you'll have to log in.
    if(result.Status != LiveConnectSessionStatus.Connected)
    {
        // This will automatically show the login screen
        result = await auth.LoginAsync(new [] {"wl.basic", "wl.signin", "wl.skydrive_update" });
    }
    if(result.Status == LiveConnectSessionStatus.Connected)
    {
        client = new LiveConnectClient(result.Session);
    }
