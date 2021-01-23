    public class EventAggregatorWrapper
    {
        private EventAggregator _eventAggregator = new EventAggregator();
        // Publish
        public void Publish<TEvent>(TEvent eventToPublish)
        {
            GetEvent<TEvent>().Publish(eventToPublish);
        }
        // Subscribe
        public SubscriptionToken Subscribe<TEvent>(
            Action<TEvent> action, 
            ThreadOption threadOption = ThreadOption.PublisherThread, 
            bool keepSubscriberReferenceAlive = false, 
            Predicate<TEvent> filter = null)
        {
            return GetEvent<TEvent>().Subscribe(action, threadOption, keepSubscriberReferenceAlive, filter);
        }
        // Unsubscribe
        public void Unsubscribe<TEvent>(SubscriptionToken token)
        {
            GetEvent<TEvent>().Unsubscribe(token);
        }
        // Helper method to get a CompositePresentationEvent to act upon.
        private CompositePresentationEvent<TEvent> GetEvent<TEvent>()
        {
            return _eventAggregator.GetEvent<CompositePresentationEvent<TEvent>>();
        }
    }
