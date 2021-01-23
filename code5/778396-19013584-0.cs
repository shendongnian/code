    using System.Threading;
    public class Activity : IDisposable
    {
        private AutoResetEvent _processing = new AutoResetEvent(false);
        private ConcurrentQueue<Action> actionsToProcess = new ConcurrentQueue<Action>();
        public void Go()
        {
            while (!Stop)
            {
                // for purposes of this example, magically assume that ProcessImmediate has not been called when this is called
                DoSomethingInteresting();
                _processing.WaitOne(2000);
                 while(!actionsToProcess.IsEmpty)
                 {
                     Action action;
                     if(actionsToProcess.TryDeque(out action))
                         action();
                 }
            }
        }
        protected virtual void DoSomethingInteresting() { }
        public void ProcessImmediate(Action action)
        {
            actionsToProcess.Enqueue(action);
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
