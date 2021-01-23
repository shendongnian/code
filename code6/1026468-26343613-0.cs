    public class PortAdapter
    {
        public event EventHandler SomethingHappened;
        private readonly SynchronizationContext context;
        public PortAdapter(SynchronizationContext context)
        {
            this.context = context ?? new SynchronizationContext();//If no context use thread pool
        }
        private void DoSomethingInteresting()
        {
            //Do something
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                //Raise the event in client's context so that client doesn't needs Invoke
                context.Post(x => handler(this, EventArgs.Empty), null);
            }
        }
    }
