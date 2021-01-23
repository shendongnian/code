    public class UnsafeSetter : Setter
    {
        private class ValueContainer
        {
            public string Property { get; set; }
            public object Value { get; set; }
        }
        private static readonly Dictionary<string, DependencyProperty> _properties = new Dictionary<string, DependencyProperty>();
        private DependencyProperty GetOrAddProperty(string name)
        {
            DependencyProperty res;
            if (!_properties.TryGetValue(name, out res))
            {
                res = DependencyProperty.RegisterAttached(
                      "Intermediate_" + name,
                      typeof(ValueContainer),
                      typeof(UnsafeSetter),
                      new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPropertyChanged)));
                _properties.Add(name, res);
            }
            return res;
        }
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var args = (ValueContainer)e.NewValue;
            var prop = GetDependencyProperty(d.GetType(), args.Property);
            if (prop == null)
            {
                throw new ArgumentException(string.Format("Dependency property {0} not found on type {1}", args.Property, d.GetType().Name));
            }
            else
            {
                var binding = args.Value as BindingBase;
                if (binding != null)
                {
                    BindingOperations.SetBinding(d, prop, binding);
                }
                else
                {
                    d.SetValue(prop, args.Value);
                }
            }
        }
        private static DependencyProperty GetDependencyProperty(Type type, string name)
        {
            if (type == null)
                return null;
            FieldInfo fieldInfo = type.GetField(name + "Property", BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo == null)
                return GetDependencyProperty(type.BaseType, name);
            return (DependencyProperty)fieldInfo.GetValue(null);
        }
        private string _unsafeProperty;
        public string PropertyName
        {
            get { return _unsafeProperty; }
            set
            {
                _unsafeProperty = value;
                UpdateBaseValue();
                base.Property = GetOrAddProperty(value);
            }
        }
        private object _unsafeValue;
        public BindingBase Binding
        {
            get { return _unsafeValue as BindingBase; }
            set
            {
                _unsafeValue = value;
                UpdateBaseValue();
            }
        }
        public new object Value
        {
            get { return _unsafeValue; }
            set
            {
                _unsafeValue = value;
                UpdateBaseValue();
            }
        }
        private void UpdateBaseValue()
        {
            base.Value = new ValueContainer
            {
                Property = PropertyName,
                Value = Value
            };
        }
    }
