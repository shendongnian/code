    public class DynamicProxy : DynamicObject, INotifyPropertyChanged
    {
        private readonly PropertyDescriptorCollection mPropertyDescriptors;
        protected PropertyInfo GetPropertyInfo(string propertyName)
        {
            return
                ProxiedObject.GetType()
                    .GetProperties()
                    .FirstOrDefault(propertyInfo => propertyInfo.Name == propertyName);
        }
        protected virtual void SetMember(string propertyName, object value)
        {
            var propertyInfo = GetPropertyInfo(propertyName);
            if (propertyInfo.PropertyType == value.GetType())
            {
                propertyInfo.SetValue(ProxiedObject, value, null);
            }
            else
            {
                var underlyingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
                if (underlyingType != null)
                {
                    var propertyDescriptor = mPropertyDescriptors.Find(propertyName, false);
                    var converter = propertyDescriptor.Converter;
                    if (converter != null && converter.CanConvertFrom(typeof (string)))
                    {
                        var convertedValue = converter.ConvertFrom(value);
                        propertyInfo.SetValue(ProxiedObject, convertedValue, null);
                    }
                }
            }
            RaisePropertyChanged(propertyName);
        }
        protected virtual object GetMember(string propertyName)
        {
            return GetPropertyInfo(propertyName).GetValue(ProxiedObject, null);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }
        #region constructor
        public DynamicProxy()
        {
        }
        public DynamicProxy(object proxiedObject)
        {
            ProxiedObject = proxiedObject;
            mPropertyDescriptors = TypeDescriptor.GetProperties(ProxiedObject.GetType());
        }
        #endregion
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type == typeof (INotifyPropertyChanged))
            {
                result = this;
                return true;
            }
            if (ProxiedObject != null && binder.Type.IsInstanceOfType(ProxiedObject))
            {
                result = ProxiedObject;
                return true;
            }
            return base.TryConvert(binder, out result);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetMember(binder.Name);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            SetMember(binder.Name, value);
            return true;
        }
        #region public properties
        public object ProxiedObject { get; set; }
        #endregion
        #region INotifyPropertyChanged Member
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
