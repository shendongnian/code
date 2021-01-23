    private static async Task AuthAsyncInternal()
    {
    	Deployment.Current.Dispatcher.BeginInvoke(async delegate()
    		{
    			liveAuthClient = new LiveAuthClient("your client id here");
    			LiveLoginResult liveLoginResult = await liveAuthClient.InitializeAsync();
    			liveLoginResult = await liveAuthClient.LoginAsync(new List<string> { "wl.signin" });
    			if (liveLoginResult.Status == LiveConnectSessionStatus.Connected)
    			{
    				session = liveLoginResult.Session;
    				liveConnectClient = new LiveConnectClient(session);
    				await Task.Run(async () =>
    					{
    						LiveOperationResult liveOperationResult = 
    							await liveConnectClient.("me");
    						dynamic meResult = liveOperationResult.Result;
    						MyEngine.userID = meResult.id;
    					});
    			}
    		});
    }
