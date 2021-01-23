    public class Session
    {
    	public string UserName { get; private set; }
    	public string PluginId { get; private set; }
    	public string SessionId { get; private set; }
    	
    	public static Session Current { get; private set; }
    	
    	public void NewSession(string userName, string pluginId, string sessionId)
    	{
    		Current = new Session 
    		{
    			UserName = userName,
    			PluginId = pluginId,
    			SessionId = sessionId
    		};
    	}
    	
    	private Session()
    	{
    	
    	}	
    }
