        public class TimeAwait
        {
            public uint DaysLeft;
            private Action action;
            private System.Timers.Timer aTimer;
    
        public TimeAwait(uint daysToWait, Action a)
        {
            action = a;
            DaysLeft = daysToWait;
    
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = daysToWait;
            aTimer.Enabled = true;
    
        }
    
        public void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            action.Invoke();
            aTimer.Stop();
        }
    }
    
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Action someAction;
                    someAction = () => Console.WriteLine(DateTime.Now);
    
                var item1 = new TimeAwait(2000, someAction);
                var item2 = new TimeAwait(4000, someAction);
    
                Console.ReadKey();
            }
            catch
            {
    
            }
        }
    }
