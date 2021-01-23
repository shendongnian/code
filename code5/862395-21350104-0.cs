    ManualResetEvent stopEvent = new ManualResetEvent(false);
    Thread checkJob = new Thread(checkStatus);
    checkJob.Start();
    
    protected void checkStatus()
    {
       //Do Checking here
       while(stopEvent.Wait(60000) == false)
       {
         // Do processing
       }
    }
