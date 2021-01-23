    private static LiveConnectSession session = null;
    private static LiveAuthClient liveAuthClient = null;
    private static LiveConnectClient liveConnectClient = null;
    
    public static async Task AuthAsync()
    {
    	await AuthAsyncInternal();
    	if (liveConnectClient != null)
    	{
    		await Task.Run(async () =>
    			{
    				LiveOperationResult liveOperationResult = 
    					await liveConnectClient.("me");
    				dynamic meResult = liveOperationResult.Result;
    				MyEngine.userID = meResult.id;
    			});
    	}
    }
    
    private static async Task AuthAsyncInternal()
    {
        liveAuthClient = new LiveAuthClient();
        LiveLoginResult liveLoginResult = await liveAuthClient.InitializeAsync();
        liveLoginResult = await liveAuthClient.LoginAsync(new List<string> { "wl.signin" });
        if (liveLoginResult.Status == LiveConnectSessionStatus.Connected)
        {
            session = liveLoginResult.Session;
            liveConnectClient = new LiveConnectClient(session);
        }
    }
