    other using .....
    
    using System.Threading;
    
    public partial class YourService : ServiceBase
    {
    	bool StopMe = false;
    	
    	protected override void OnStart(string[] args)
    	{
    		MessageLog("Service Start", "Service Start at: " + DateTime.Now.ToString());
    		this.StopMe = false;
    		this.StartTheThread();		
    	}
    	protected override void OnStop()
    	{
    		this.StopMe = true; 
    	}
    	
    	Thread SMSSender;
        private void StartTheThread()
        {
            ThreadStart st = new ThreadStart(DoProcess);
            SMSSender = new Thread(st);
            SMSSender.Start();
        }
        
        private void DoProcess()
        {
    		while(!this.StopMe)
    		{
    			MessageLog("Timer Start", "Call from thread loop  at: " + DateTime.Now.ToString());
    			List<User> ListUser = new List<User>();
    			//Code/function to be called to populate ListUser
    			
    			foreach(User usr in ListUser)
    			{
    				//Code/function to be called to send sms here
    				
    				if (this.StopMe) break; //stop the thread when stop flag is set
    			}
    			
    			
    			Thread.Sleep(60*1000); //sleep for 1 minute
    		}
    		
    		MessageLog("Service Stop", "Service Stop at: " + DateTime.Now.ToString()); 
        }
    }
