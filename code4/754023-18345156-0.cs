    public void onTimer1ElapsedEvent(object source, ElapsedEventArgs e)
    {
        lock (locker) {
                globalVar = 1;
                Console.WriteLine("Timer1 var = {0}", globalVar);
            
        } 
    }
    public void onTimer2ElapsedEvent(object source, ElapsedEventArgs e)
    {
        lock (locker) {
                globalVar = 2;
                Thread.Sleep(2000);  // simulates a WCF request that may take time
                Console.WriteLine("Timer2 var = {0}", globalVar);
        } 
    }
