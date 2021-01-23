    public class MyService : ServiceBase
    {
        private Timer _executeTimer;
        private bool _isRunning;
        public MyService()
        {
            _executeTimer = new Timer();
            _executeTimer.Interval = 1000 * 60; // 1 minute
            _executeTimer.Elapsed += _executeTimer_Elapsed;
            _executeTimer.Start();
        }
        private void _executeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_isRunning) return; // logic already running, skip out.
            try
            {
                _isRunning = true; // set timer event running.
                
                // perform some logic.
            }
            catch (Exception ex)
            {
                // perform some error handling. You should be aware of which 
                // exceptions you can handle and which you can't handle. 
                // Blanket handling Exception is not recommended.
                throw;
            }
            finally
            {
                _isRunning = false; // set timer event finished.  
            }
        }
        protected override void OnStart(string[] args)
        {
            // perform some startup initialization here.
            _executeTimer.Start();
        }
        protected override void OnStop()
        {
            // perform shutdown logic here.
            _executeTimer.Stop();
        }
    }
