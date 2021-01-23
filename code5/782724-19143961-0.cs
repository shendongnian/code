    public void WorkAtInterval(long interval, Action<object,EventArgs> work)
                {
                    //heartbeat in miliseconds
                    tmr.Interval = interval;
                    tmr.Start();
                    tmr.Elapsed += new ElapsedEventHandler(work);
                }
    
    private static void sampleWork(object interval)
            {
                Console.WriteLine("The interval is: {0}",interval);
            }  
  
    static void Main(string[] args)
            {
                HeartBeat heart = new HeartBeat();
    
                var interval = heart.HeartBeatInterval;
    
                heart.WorkAtInterval(interval,(o,s) => sampleWork(interval));
    
                Console.Read();
            }
