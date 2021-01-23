    public class Subscription
    {
        #region Members
        List<Observer> _observerList = new List<Observer>();
        #endregion
        public void Unsubscribe(string subscription)
        {
            var observers = _observerList.Where(o => o.Subscription == subscription);
            foreach (var observer in observers)
            {
                MessageBus.Instance.Unsubscribe(observer.Subscription, observer.Respond);
            }
            _observerList.Where(o => o.Subscription == subscription).ToList().ForEach(o => _observerList.Remove(o));
        }
        public void Subscribe(string subscription, Action<object> response)
        {
            MessageBus.Instance.Subscribe(subscription, response);
            _observerList.Add(new Observer() { Subscription = subscription, Respond = response });
        }
        public void SubscribeFirstPublication(string subscription, Action<object> response)
        {
            MessageBus.Instance.SubscribeFirstPublication(subscription, response);
        }
    }
