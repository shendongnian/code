    public class Myhelper:IRegisteredObject
    {
    	private Myhelper(){}
    
        // factory
        public static Myhelper Create() {
            var hlp = new Myhelper();
            HostingEnvironment.RegisterObject(hlp); // register ourself!
            return hlp; }
    
        bool keepRunning = true;
        ManualResetEvent mre = new ManualResetEvent(false);
    
        // our DoWork method!
        public void FooBar(object args) {
            EventLog.WriteEntry(".NET Runtime", "started");
            // implement your long running function, 
            // be sure to check regularly if you need to stop processing
            while (keepRunning)
            {
                Trace.Write("+");
                mre.WaitOne(1000); // do work, (used this instead of Thread.Sleep())
            }
            EventLog.WriteEntry(".NET Runtime","stopped");
            HostingEnvironment.UnregisterObject(this);  }
        
        // this gets caled when the HostingEnvironment is stopping
        public void Stop(bool immediate)
        {
            keepRunning = false;
            mre.Set(); // signal nicely
        }
    }
