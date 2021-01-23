    public class MessageBus
    {
        #region Singleton
        static MessageBus _messageBus = null;
        private MessageBus() { }
        public static MessageBus Instance
        {
            get
            {
                if (_messageBus == null)
                {
                    _messageBus = new MessageBus();
                }
                return _messageBus;
            }
        }
        #endregion
        #region Members
        List<Observer> _observers = new List<Observer>();
        List<Observer> _oneTimeObservers = new List<Observer>();
        List<Observer> _waitingSubscribers = new List<Observer>();
        List<Observer> _waitingUnsubscribers = new List<Observer>();
        int _publishingCount = 0;
        #endregion
        public void Subscribe(string message, Action<object> response)
        {
            Subscribe(message, response, _observers);
        }
        public void SubscribeFirstPublication(string message, Action<object> response)
        {
            Subscribe(message, response, _oneTimeObservers);
        }
        public int Unsubscribe(string message, Action<object> response)
        {
            var observers = new List<Observer>(_observers.Where(o => o.Respond == response).ToList());
            observers.AddRange(_waitingSubscribers.Where(o => o.Respond == response));
            observers.AddRange(_oneTimeObservers.Where(o => o.Respond == response));
            if (_publishingCount == 0)
            {
                observers.ForEach(o => _observers.Remove(o));
            }
            else
            {
                _waitingUnsubscribers.AddRange(observers);
            }
            return observers.Count;
        }
        public int Unsubscribe(string subscription)
        {
            var observers = new List<Observer>(_observers.Where(o => o.Subscription == subscription).ToList());
            observers.AddRange(_waitingSubscribers.Where(o => o.Subscription == subscription));
            observers.AddRange(_oneTimeObservers.Where(o => o.Subscription == subscription));
            if (_publishingCount == 0)
            {
                observers.ForEach(o => _observers.Remove(o));
            }
            else
            {
                _waitingUnsubscribers.AddRange(observers);
            }
            return observers.Count;
        }
        public void Publish(string message, object payload)
        {
            _publishingCount++;
            Publish(_observers, message, payload);
            Publish(_oneTimeObservers, message, payload);
            Publish(_waitingSubscribers, message, payload);
            _oneTimeObservers.RemoveAll(o => o.Subscription == message);
            _waitingUnsubscribers.Clear();
            _publishingCount--;
        }
        private void Publish(List<Observer> observers, string message, object payload)
        {
            Debug.Assert(_publishingCount >= 0);
            var subscribers = observers.Where(o => o.Subscription.ToLower() == message.ToLower());
            foreach (var subscriber in subscribers)
            {
                subscriber.Respond(payload);
            }
        }
        public IEnumerable<Observer> GetObservers(string subscription)
        {
            var observers = new List<Observer>(_observers.Where(o => o.Subscription == subscription));
            return observers;
        }
        public void Clear()
        {
            _observers.Clear();
            _oneTimeObservers.Clear();
        }
        #region Helpers
        private void Subscribe(string message, Action<object> response, List<Observer> observers)
        {
            Debug.Assert(_publishingCount >= 0);
            var observer = new Observer() { Subscription = message, Respond = response };
            if (_publishingCount == 0)
            {
                observers.Add(observer);
            }
            else
            {
                _waitingSubscribers.Add(observer);
            }
        }
        #endregion
    }
