    private static Dictionary<Type, List<object>> _subscribers;
        public static function Subscribe<T>(IMyMessageReceiver<T> receiver) where T: IMyMessage
        {
          Type messageType = typeof (T);
          List<object> listeners;
        
          if(!_subscribers.TryGetValue(messageType, out listeners))
          {
            // no list found, so create it
            List<object> newListeners = new List<object>();
            newListeners.Add(receiver)
            _subscribers.add(messageType, newListeners);
        
          }
        
          var messageReceivers = listeners.Cast<IMyMessageReceiver<T>>();
    }
