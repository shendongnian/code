    using System.Threading;
    public class Activity : IDisposable
    {
        private AutoResetEvent _processing = new AutoResetEvent(false); 
        public void Go()
        {
            while (!Stop)
            {
                // for purposes of this example, magically assume that ProcessImmediate has not been called when this is called
                DoSomethingInteresting();
                _processing.WaitOne(2000);
            }
        }
        protected virtual void DoSomethingInteresting() { }
        public void ProcessImmediate()
        {
            _processing.Set();
        }
        public bool Stop { get; set; }
        public void Dispose() 
        {
            if (_processing != null)
            {
                _processing.Dispose();
                _processing = null;
            }
        }
    }
