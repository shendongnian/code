    public class MessageBus
    {
        #region Constants
        const string SUBSCRIBE = "subscribe";
        const string PUBLISH = "publish";
        #endregion
        #region Singleton
        static MessageBus _eventAggregator = null;
        private MessageBus() { }
        public static MessageBus Instance
        {
            get
            {
                if (_eventAggregator == null)
                {
                    _eventAggregator = new MessageBus();
                }
                return _eventAggregator;
            }
        }
        #endregion
        #region Members
        List<Observer> _observers = new List<Observer>();
        #endregion
        public void Register(ParticipationType participationType, string subscription, Action<object> response)
        {
            object payload = null;
            Register(participationType, subscription, response, payload);
        }
        public void Register(ParticipationType participationType, string subscription, Action<object> response, object payload)
        {
            string subscriptionType = null;
            if (participationType == ParticipationType.SUBSCRIBER)
            {
                subscriptionType = string.Format("{0}_{1}", SUBSCRIBE, subscription);
            }
            else if (participationType == ParticipationType.PUBLISHER)
            {
                subscriptionType = string.Format("{0}_{1}", PUBLISH, subscription);
            }
            var observer = new Observer() { Subscription = subscriptionType, Respond = response };
            _observers.Add(observer);
            foreach (var observerItem in _observers)
            {
                var publication = string.Format("{0}_{1}", PUBLISH, subscription);
                if (observerItem.Subscription == publication)
                {
                    observerItem.Respond(payload);
                }
            }
        }
        public void Publish(string publication, object payload)
        {
            var subscription = string.Format("{0}_{1}", SUBSCRIBE, publication);
            var observers = _observers.Where(o => o.Subscription == subscription);
            observers.ToList().ForEach(o => o.Respond(payload));
        }
        public void Clear()
        {
            _observers.Clear();
        }
    }
