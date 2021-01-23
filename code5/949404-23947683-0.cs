    public class MyProtocol
    {
        private Task connectTask;
        public Task Connect()
        {
            var tcpIpConnectTask = mTcpIpProtocol.Connect();
            tcpIpConnectTask.ContinueWith(t =>
            {
                bool finished = false;
    			Task readAsyncTask = null;
    			
    			while(!finsihed)
    			{			   
    				NetworkStream.WriteASync().
    				ContinueWith(t1 =>
    				{
    				     if(t1.Exception == null)
    					 {					
    						readAsyncTask = NetworkStream.ReadASync().
    						ContinueWiht(t2 => 
    						{
    						    if(t2.Exception == null)
    							{
    								if(t2.Result == /*Desired Response*/)
    								{ 
    									finished = true;
    									connectedTask = t2;
    								}
    							}
    							else
    							{	
    							    // Handle ReadAsync error
    							}
    						}, null, TaskScheduler.Default);
    					}
    					else
    					{
    					   // handle WriteAsync error
    					}
    				}, null, TaskScheduler.Default);	
    				
    				// Wait for the read operation to complete. This can cause a deadlock
    				// when called from a UI thread as Wait() is a blocking call. Ensure we are waiting
    				// on a background thread by specifying TaskScheduler.Default
    				readAsyncTask.Wait();
    			}
            }, null, TaskScheduler.Default);
    		
            return connectTask;
    }
    
