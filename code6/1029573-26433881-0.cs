    using System.Threading;
    public class MyClass
    {
        // whatever stuff you have
        // Timer that will update the data
        private Timer _updateTimer;
        public MyClass()
        {
            // initialization
            // Start the timer
            _updateTimer = new Timer(
                UpdateTimerProc, null, 
                TimeSpan.FromSeconds(864),
                TimeSpan.FromSeconds(864));
        }
        private void UpdateTimerProc(object state)
        {
            // do SQL update here
        }
    }
