    public class Timer
    {
        private SynchronizationContext syncContext;
        public Timer()
        {
            syncContext = SynchronizationContext.Current;
        }
        public event EventHandler Tick;
        private void OnTick()
        {
            syncContext.Send(state =>
            {
                if (Tick != null)
                    Tick(this, EventArgs.Empty);
            }, null);
        }
        //TODO other stuff to actually fire the tick event
    }
