    public partial class TestService : ServiceBase
     {
         private static System.Timers.Timer aTimer;
         protected override void OnStart(string[] args)
         {
            aTimer = new Timer(10000 * 6 * 5); //  5 minutes interval
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            
            foo();
            aTimer.Enabled = true;
         }
         private void OnTimedEvent(object source, ElapsedEventArgs e)
         {
           foo();
         }
         private void foo(){
            .....
         }
     }
