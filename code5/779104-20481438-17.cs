    public sealed class PropertyChangeSubscriber<T> : PropertyChangeSubscriberBase
    {
        private PropertyChangePublisherBase _publisher;
        public new T Value
        {
            get
            {
                if (base.Value == null)
                    return default(T);
                if (base.Value.GetType() != typeof(T))
                    throw new InvalidOperationException(String.Format("Property {0} on object of type {1} does not match the type Generic type specified {2}.", _propertyName, _publisher.GetType(), typeof(T)));
                return (T)base.Value;
            }
            set { base.Value = value; }
        }
        public PropertyChangeSubscriber(string propertyName, PropertyChangePublisherBase bindingPublisher)
            : base(propertyName, bindingPublisher)
        {
            _publisher = bindingPublisher;
        }
    }
