    public static async Task LoginAsync(this Host host, APIServerType serverType, string name, string id)
    {
    	var tcs = new TaskCompletionSource<LoginDetails>();
    	var loginDetails = new LoginDetails();
    	try
    	{
    		host.LoginSuccess += (object obj, LoginSuccessEventHandler e) =>
    		{
    			loginDetails.IsSuccess = true;
    			tcs.SetResult(loginDetails);
    		}
    		
    		host.LoginFailure += (object obj, LoginFailureEventHandler e) =>
    		{
    			loginDetails.IsSuccess = false;
    			tcs.SetResult(loginDetails);
    		}
    		
    		host.Notification += (object obj, NotificationEventHandler e) =>
    		{
    			loginDetails.Notificaiton = e.Notification // I assume it would look something like this
    			tcs.SetResult(loginDetails);
    		}
    	}
    	catch (Exception e)
    	{
    		tcs.SetException(e);
    	}
    	
    	host.Login(serverType, name, id);
    	return tcs.Task;
    }
