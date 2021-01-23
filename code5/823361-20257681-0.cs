    [MarkupExtensionReturnType(typeof(string))]
    public class MyBindingExtension : MarkupExtension
    {
        private readonly string _key;
        public MyBindingExtension(string key)
        {
            _key = key;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // TODO: your code here to retrieve the converted value.
        }
    }
