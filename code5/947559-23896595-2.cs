    public class StateChangeArgs : EventArgs
    {
        private bool EventInfo;
        public StateChangeArgs(bool state)
        {
            EventInfo = state;
        }
        public bool GetInfo()
        {
            return EventInfo;
        }
            
    }
