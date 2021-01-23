    public class Service : IService
    {
    	[WebMethod(Description = "Returns some sample data")]
    	public bool DoWork()
    	{
    		AuthHeader authentication = SoapHeaderHelper<AuthHeader>.GetInputHeader("AuthHeader");
    		if (@"userName".Equals(authentication.Username) && @"pwd".Equals(authentication.Password))
    		{
    			//Do your thing
    			return true;
    
    		}
    		else
    		{
    			//if authentication fails
    			return false;
    		}
    	}
    }
	
	
    
