    public class WCFService : IWCFService
    {
      public WCFService()
      {        
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Elapsed += new System.Timers.ElapsedEventHandler(WCFService_Elapsed);
        timer.Interval = 1000;
        timer.Enabled = true;         
        timer.Start();
      }
    void WCFService_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {   
       //Do Checking
    }
