    public static class HostExtensions
    {
    	public static async Task LoginAsync(this Host host, APIServerType serverType, string name, string id)
    	{
    		var tcs = new TaskCompletionSource<bool>();
    		try
    		{
    			host.LoginSuccess += (object obj, LoginSuccessEventHandler e) =>
    			{
    				tcs.SetResult(true);
    			}
    			
    			host.LoginFailure += (object obj, LoginFailureEventHandler e) =>
    			{
    				tcs.SetResult(false);
    			}
    		}
    		catch (Exception e)
    		{
    			tcs.SetException(e);
    		}
    		
    		host.Login(serverType, name, id);
    		return tcs.Task;
    	}
    }
