    public class LocalName
    {
        public static string GetBaseName(FrameworkElement obj)
        {
            return (string)obj.GetValue(BaseNameProperty);
        }
        public static void SetBaseName(FrameworkElement obj, string value)
        {
            obj.SetValue(BaseNameProperty, value);
        }
        public static readonly DependencyProperty BaseNameProperty =
            DependencyProperty.RegisterAttached("BaseName", typeof(string),
            typeof(LocalName),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.Inherits));
    }
    public class LocalNameExtension : MarkupExtension
    {
        private string _qualifier;
        public LocalNameExtension()
        {
        }
        public LocalNameExtension(string qualifier)
        {
            _qualifier = qualifier;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var targetProvider = (IProvideValueTarget)
                serviceProvider.GetService(typeof(IProvideValueTarget));
            var target = (FrameworkElement)targetProvider.TargetObject;
            string name = LocalName.GetBaseName(target);
            if (_qualifier != null) { name += _qualifier; }
            return name;
        }
    public class UniqueNameExtension : MarkupExtension
    {
        private string _name;
        public UniqueNameExtension()
        {
            _name = Guid.NewGuid().ToString("N");
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _name;
        }
    }
