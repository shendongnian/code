    public abstract class Awaiter : INotifyCompletion
    {
        private readonly List<Action> _continuations = new List<Action>();
        public bool IsCompleted
        {
            get { return false; }
        }
        public abstract void GetResult();
        public void OnCompleted(Action continuation)
        {
            lock (_continuations)
            {
                var syncContext = SynchronizationContext.Current;
                if (syncContext != null)
                {
                    _continuations.Add(() => syncContext.Send(s => continuation(), null));
                }
                else
                {
                    _continuations.Add(continuation);
                }                
            }
        }
        public void RunContinuations()
        {
            Action[] continuations;
            lock (_continuations)
            {
                continuations = _continuations.ToArray();
                _continuations.Clear();
            }
            foreach (var continuation in continuations)
            {
                continuation();
            }
        }
        public Awaiter GetAwaiter()
        {
            return this;
        }
    }
