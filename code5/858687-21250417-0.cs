    LiveAuthClient auth = new LiveAuthClient();
    LiveLoginResult loginResult = await auth.InitializeAsync(new string[] { "wl.basic" });
    if ( loginResult.Status == LiveConnectSessionStatus.Connected )
    {
    	LiveConnectClient connect = new LiveConnectClient( auth.Session );
        ...
