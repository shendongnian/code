    public abstract class PropertyChangePublisherBase : INotifyPropertyChanged
    {
        private Dictionary<string, PropertyInfo> _properties;
        private bool _cacheProperties;
        public bool CacheProperties
        {
            get { return _cacheProperties; }
            set
            {
                _cacheProperties = value;
                if (_cacheProperties && _properties == null)
                    _properties = new Dictionary<string, PropertyInfo>();
            }
        }
        protected PropertyChangePublisherBase(bool cacheProperties)
        {
            CacheProperties = cacheProperties;
            if (cacheProperties)
                _properties = new Dictionary<string, PropertyInfo>();
        }
        public bool ContainsBinding(PropertyChangedEventHandler handler)
        {
            if (PropertyChanged == null)
                return false;
            return PropertyChanged.GetInvocationList().Contains(handler);
        }
        public object GetPropertValue(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || String.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Argument must be the name of a property of the current instance.", "propertyName");
            return ProcessGetPropertyValue(propertyName);
        }
        protected virtual object ProcessGetPropertyValue(string propertyName)
        {
            if (_cacheProperties)
            {
                if (_properties.ContainsKey(propertyName))
                {
                    return _properties[propertyName].GetValue(this, null);
                }
                else
                {
                    var property = GetType().GetProperty(propertyName);
                    _properties.Add(propertyName, property);
                    return property.GetValue(this, null);
                }
            }
            else
            {
                var property = GetType().GetProperty(propertyName);
                return property.GetValue(this, null);
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
