    [TestMethod]
    public void eventaggregator()
    {
        // Setup
        var subscription = "my_subscription";
        bool messageReceived = false;
        EventAggregator.Instance.Register(subscription, (parameter) =>
            {
                // Logic goes here...
                messageReceived = true;
            });
        // Test
        EventAggregator.Instance.Publish(subscription, "a parameter for subscibers");
        // Verify
        Assert.IsTrue(messageReceived);
    }
    public class EventAggregator
    {
        #region Singleton
        static EventAggregator _eventAggregator = null;
        private EventAggregator() { }
        public static EventAggregator Instance
        {
            get
            {
                if (_eventAggregator == null)
                {
                    _eventAggregator = new EventAggregator();
                }
                return _eventAggregator;
            }
        }
        #endregion
        List<Observer> _observers = new List<Observer>();
        public void Register(string subscription, Action<object> response)
        {
            var observer = new Observer() { Subscription = subscription, Respond = response };
            _observers.Add(observer);
        }
        public void Publish(string subscription, object payload)
        {
            foreach (var observer in _observers)
            {
                if (observer.Subscription == subscription)
                {
                    observer.Respond(payload);
                }
            }
        }
    }
    public class Observer
    {
        public string Subscription { get; set; }
        public Action<object> Respond {get; set; }
    }
