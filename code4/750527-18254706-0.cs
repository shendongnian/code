    public class Sample
    {
        public void Run()
        {
            var state = new State();
            ThreadPool.QueueUserWorkItem(DoWork, state);
            ThreadPool.QueueUserWorkItem(ShowProgress, state);
            WaitHandle.WaitAll(new WaitHandle[] {state.AutoResetEvent});
            Console.WriteLine("Completed");
        }
        public void DoWork(object state)
        {
            //do your work here
            for (int i = 0; i < 10; i++)
            {
                ((State) state).Status++;
                Thread.Sleep(1000);
            }
            ((State) state).AutoResetEvent.Set();
        }
        public void ShowProgress(object state)
        {
            var s = (State) state;
            while (!s.IsCompleted())
            {
                if (s.PrintedStatus != s.Status)
                    Console.WriteLine(s.Status);
                s.PrintedStatus = s.Status;
            }
        }
        public class State
        {
            public State()
            {
                AutoResetEvent = new AutoResetEvent(false);
            }
            public AutoResetEvent AutoResetEvent { get; private set; }
            public int Status { get; set; }
            public int PrintedStatus { get; set; }
            private bool _completed;
            public bool IsCompleted()
            {
                return _completed;
            }
            public void Completed()
            {
                _completed = true;
                AutoResetEvent.Set();
            }
        }
    }
