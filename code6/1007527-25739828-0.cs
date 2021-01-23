    protected void Application_BeginRequest(object sender, EventArgs e)
    {
    	StringBuilder sb = new StringBuilder();
    	HttpContext.Current.Items["DebugLog"] = sb;
    	Logger.LogMemory("Timestamp::" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
    }
    
    protected void Application_EndRequest(object sender, EventArgs e)
    {
    	Logger.Log(((StringBuilder)HttpContext.Current.Items["DebugLog"]).ToString());
    }
    
    class Logger
    {
    	public static void Log(string message)
    	{
    		//Log here
    	}
    	
    	public static void LogMemory(string message)
    	{
    		((StringBuilder)HttpContext.Current.Items["DebugLog"]).Append(message);
    	}
    }
    
    class A: Logger
    {
    	public void SomeMethod()
    	{
    		LogMemory("some message for logging");
    	}
    }
