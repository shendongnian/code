    abstract class TimerAction : ITimerAction
    {
        public virtual int Seconds
        {
            get;
            set; 
        }
        public virtual bool Completed
        {
            get;
            protected set;
        }
        public virtual bool Started
        {
            get;
            protected set; 
        }
        public abstract void OnStart();
        public abstract void OnComplete();
    }
    class TimerActionList : ITimerActionList
    {
        public event EventHandler OnCompletedEvent;
        private readonly IList<ITimerAction> actions = new List<ITimerAction>();
        private bool working = false;
        private Thread myThread;
        public void Add(ITimerAction action)
        {
            if (working)
            {
                throw new InvalidOperationException("Cannot add new timers when work is already in progress");
            }
            actions.Add(action);
        }
        protected virtual void DoWork()
        {
            working = true;
            int currentStep = 0, maxSteps = actions.Count;
            while (currentStep < maxSteps)
            {
                ITimerAction action = actions[currentStep];
                if (!action.Started)
                {
                    action.OnStart();
                }
                if (action.Completed)
                {
                    currentStep++;
                    continue;
                }
                if (action.Seconds == 0)
                {
                    action.OnComplete();
                    continue;
                }
                action.Seconds--;
                Thread.Sleep(1000);
            }
            Completed();
        }
        public void Work()
        {
            if (working)
            {
                throw new InvalidOperationException("Already running!");
            }
            working = true;
            myThread = new Thread(DoWork);
            myThread.Start();
        }
        protected virtual void Completed()
        {
            myThread = null;
            working = false;
            actions.Clear();
            var local = OnCompletedEvent;
            if (local != null)
            {
                local.Invoke(this, EventArgs.Empty);
            }
        }
    }
