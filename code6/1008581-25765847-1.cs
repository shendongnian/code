    public abstract class BaseEvent
    {
        public DateTime TimeStamp
        {
            get
            {
                if (_timestamp == null)
                    ParseEvent();
    
                return _timestamp.Value;
            }
            protected set { _timestamp = value; }
        }
    
        protected BaseEvent(object stuff)
        {
        }
    
        protected abstract void ParseEvent();
    
        private DateTime? _timestamp;
    }
