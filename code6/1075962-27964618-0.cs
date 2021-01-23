    public class GameServer
    {
        // You can change the type of these if you need to pass arguments to the handlers.
        public event EventHandler Idle;
        public event EventHandler Aggro;
        void OnIdle()
        {
            EventHandler RaiseIdleEvent = Idle;
            if (null != RaiseIdleEvent)
            {
                // Change the EventArgs.Empty to an appropriate value to pass arguments to the handlers
                RaiseIdleEvent(this, EventArgs.Empty);
            }
        }
        void OnAggro()
        {
            EventHandler RaiseAggroEvent = Aggro;
            if (null != RaiseAggroEvent)
            {
                // Change the EventArgs.Empty to an appropriate value to pass arguments to the handlers
                RaiseAggroEvent(this, EventArgs.Empty);
            }
        }
    }
