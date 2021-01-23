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
    	}
    }
