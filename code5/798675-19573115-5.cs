    using System;
    using SDK;
    
    namespace Plugin
    {
    	public class Plugin : MarshalByRefObject, IPlugin
    	{
            public Plugin()
    		{
    		}
    
    	    public void SomeMethod()
    	    {
    	        Console.WriteLine("SomeMethod");
    	    }
    
            public SomeSDKType GetSDKType()
            {
                var obj = new SomeSDKType();
                obj.SDKDelegate = () => Console.WriteLine("Delegate called from {0}", AppDomain.CurrentDomain.FriendlyName);
                return obj;
            }
        }
    }
