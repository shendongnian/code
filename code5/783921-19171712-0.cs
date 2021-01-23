    public interface class ICommonEvents 
    {
        /// <summary>
        /// Internal method for storing error messages to our event
        /// </summary>
        /// <param name="message"></param>
        /// <param name="showException"></param>
        /// <param name="exception"></param>
        public void OnError(string message, OnErrorEventsArgs.ShowExceptionLevel showException, Exception exception);
    
        /// <summary>
        /// Internal event handler allowing for logging of events within the class
        /// </summary>
        private EventHandler<OnErrorEventsArgs> _onErrorEvent;
    
        /// <summary>
        /// Public event handler allowing for accessibility outside of the class
        /// </summary>
        public event EventHandler<OnErrorEventsArgs> OnErrorEvent;
    }
    
    public class CommonEvents : DisposableObject, ICommonEvents
    {
        /// <summary>
        /// Internal method for storing error messages to our event
        /// </summary>
        /// <param name="message"></param>
        /// <param name="showException"></param>
        /// <param name="exception"></param>
        public void OnError(string message, OnErrorEventsArgs.ShowExceptionLevel showException, Exception exception)
        {
            if (_onErrorEvent == null) return;
    
            var e = new OnErrorEventsArgs(message, showException, exception);
    
            _onErrorEvent(this, e);
        }
    
        /// <summary>
        /// Internal event handler allowing for logging of events within the class
        /// </summary>
        private EventHandler<OnErrorEventsArgs> _onErrorEvent;
    
        /// <summary>
        /// Public event handler allowing for accessibility outside of the class
        /// </summary>
        public event EventHandler<OnErrorEventsArgs> OnErrorEvent
        {
            add { _onErrorEvent += value; }
            remove { _onErrorEvent += value; }
        }
    }
    
    public class ItemDal : CommonEvents
    { ...
