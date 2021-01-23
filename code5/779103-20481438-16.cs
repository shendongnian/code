    public abstract class PropertyChangeSubscriberBase
    {
        protected readonly string _propertyName;
        protected virtual object Value { get; set; }
        protected PropertyChangeSubscriberBase(string propertyName, PropertyChangePublisherBase bindingPublisher)
        {
            _propertyName = propertyName;
            AddBinding(propertyName, this, bindingPublisher);
        }
        ~PropertyChangeSubscriberBase()
        {
            RemoveBinding(_propertyName);
        }
        public void Unbind()
        {
            RemoveBinding(_propertyName);
        }
        #region Static Fields
        private static List<string> _bindingNames = new List<string>();
        private static List<PropertyChangeSubscriberBase> _subscribers = new List<PropertyChangeSubscriberBase>();
        private static List<PropertyChangePublisherBase> _publishers = new List<PropertyChangePublisherBase>();
        #endregion
        #region Static Methods
        private static void PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            string propertyName = args.PropertyName;
            if (_bindingNames.Contains(propertyName))
            {
                int i = _bindingNames.IndexOf(propertyName);
                var publisher = _publishers[i];
                var subscriber = _subscribers[i];
                subscriber.Value = publisher.GetPropertValue(propertyName);
            }
        }
        public static void AddBinding(string propertyName, PropertyChangeSubscriberBase subscriber, PropertyChangePublisherBase publisher)
        {
            if (!_bindingNames.Contains(propertyName))
            {
                _bindingNames.Add(propertyName);
                _publishers.Add(publisher);
                _subscribers.Add(subscriber);
                if (!publisher.ContainsBinding(PropertyChanged))
                    publisher.PropertyChanged += PropertyChanged;
            }
        }
        public static void RemoveBinding(string propertyName)
        {
            if (_bindingNames.Contains(propertyName))
            {
                int i = _bindingNames.IndexOf(propertyName);
                var publisher = _publishers[i];
                _bindingNames.RemoveAt(i);
                _publishers.RemoveAt(i);
                _subscribers.RemoveAt(i);
                if (!_publishers.Contains(publisher))
                    publisher.PropertyChanged -= PropertyChanged;
            }
        }
        #endregion
    }
	
