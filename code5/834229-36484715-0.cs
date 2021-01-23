    public class DynamicResourceBinding : MarkupExtension
    {
        public DynamicResourceBinding(string path)
        {
            binding = new Binding(path);
        }
        #region Binding Members
        public PropertyPath Path
        {
            get { return binding.Path; }
            set { binding.Path = value; }
        }
        public string XPath
        {
            get { return binding.XPath; }
            set { binding.XPath = value; }
        }
        [DefaultValue(BindingMode.Default)]
        public BindingMode Mode
        {
            get { return binding.Mode; }
            set { binding.Mode = value; }
        }
        [DefaultValue(UpdateSourceTrigger.Default)]
        public UpdateSourceTrigger UpdateSourceTrigger
        {
            get { return binding.UpdateSourceTrigger; }
            set { binding.UpdateSourceTrigger = value; }
        }
        public IValueConverter Converter
        {
            get { return binding.Converter; }
            set { binding.Converter = value; }
        }
        public object ConverterParameter
        {
            get { return binding.ConverterParameter; }
            set { binding.ConverterParameter = value; }
        }
        [TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
        public CultureInfo ConverterCulture
        {
            get { return binding.ConverterCulture; }
            set { binding.ConverterCulture = value; }
        }
        public object Source
        {
            get { return binding.Source; }
            set { binding.Source = value; }
        }
        public string ElementName
        {
            get { return binding.ElementName; }
            set { binding.ElementName = value; }
        }
        public RelativeSource RelativeSource
        {
            get { return binding.RelativeSource; }
            set { binding.RelativeSource = value; }
        }
        public object FallbackValue
        {
            get { return binding.FallbackValue; }
            set { binding.FallbackValue = value; }
        }
        private readonly Binding binding;
        #endregion Binding Members
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (provideValueTarget != null)
            {
                var targetObject = provideValueTarget.TargetObject as FrameworkElement;
                if (targetObject != null)
                {
                    var targetProperty = provideValueTarget.TargetProperty as DependencyProperty;
                    if (targetProperty != null)
                    {
                        targetObject.SetBinding(EnsureResourceKeyProperty(targetProperty), binding);
                    }
                }
            }
            return null;
        }
        private static readonly object locker = new object();
        public static DependencyProperty EnsureResourceKeyProperty(DependencyProperty targetProperty)
        {
            DependencyProperty resourceKeyProperty;
            lock (locker)
            {
                if (!DirectMap.TryGetValue(targetProperty, out resourceKeyProperty))
                {
                    resourceKeyProperty = RegisterResourceKeyProperty(targetProperty);
                    DirectMap.Add(targetProperty, resourceKeyProperty);
                    ReverseMap.Add(resourceKeyProperty, targetProperty);
                }
            }
            return resourceKeyProperty;
        }
        private static DependencyProperty RegisterResourceKeyProperty(DependencyProperty targetProperty)
        {
            return DependencyProperty.RegisterAttached(targetProperty.Name + "_ResourceKey", typeof(object), typeof(DynamicResourceBinding),
                new PropertyMetadata(ResourceKeyChanged));
        }
        private static void ResourceKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = d as FrameworkElement;
            if (fe != null)
            {
                lock (locker)
                {
                    DependencyProperty targetProperty;
                    if (ReverseMap.TryGetValue(e.Property, out targetProperty))
                    {
                        fe.SetResourceReference(targetProperty, e.NewValue);
                    }
                }
            }
        }
        private static readonly Dictionary<DependencyProperty, DependencyProperty> DirectMap = new Dictionary<DependencyProperty, DependencyProperty>();
        private static readonly Dictionary<DependencyProperty, DependencyProperty> ReverseMap = new Dictionary<DependencyProperty, DependencyProperty>();
    }
