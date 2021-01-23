    public abstract ActionBasedEventHandler<TEvent>
    {
        private readonly Action<TEvent> _action;
    
        protected ActionBasedEventHandler(Action<TEvent> action)
        {
            _action = action;
        }
        
        public void Handle(TEvent e)
        {
            _action(e);
        }
    }
