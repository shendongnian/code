    internal class MyClass
    {
    	private ApiObject apiObject;
    	
    	internal MyClass()
    	{
    		this.apiObject = new ApiObject();
    		Initialize();
    	}
    		
    	private void Initialize()
    	{
    		using (ManualResetEvent syncEvent = new ManualResetEvent())
    		{
    			ApiStateUpdateEventHandler handler = null;
    
    			handler = delegate(string who, int howMuch) 
    			{
    				bool cond1 = false;
    				bool cond2 = false;
    
    				if(who.Equals("Something") && howMuch == 1)
    				cond1 = true;
    				else if(who.Equals("SomethingElse") && howMuch == 1)
    					cond2 = true;        	
    
    				//wait for both conditions to be true
    
    				if ( !cond1 && !cond2 )
    					return;
    
    				this.apiObject.ApiStateUpdate -= handler;
    
    				syncEvent.Set();
    			};
    
    			this.apiObject.ApiStateUpdate += handler;
    			WaitWithDoEvents(syncEvent, Timeout.Infinite);
    		}
    	}
    }
