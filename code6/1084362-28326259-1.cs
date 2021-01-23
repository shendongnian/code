    [MarkupExtensionReturnType(typeof(BindingBase))]
    [ValueConversion(typeof(object), typeof(string))]
    public sealed class ConcatenateExtension : MarkupExtension, IValueConverter
    {
        public ConcatenateExtension()
        {
            Separator = ",";
        }
        public ConcatenateExtension(string path)
            : this()
        {
            Path = path;
        }
        public string Path { get; set; }
        public string Property { get; set; }
        public string Separator { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding(Path);
            binding.Converter = this;
            return binding;
        }
        object IValueConverter.Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            // 'value' is the property value obtained by binding to `Path`
            // We're assuming here that 'value' can be enumerated
            // Code will obviously throw an exception if it can't
            IEnumerable<object> sequence =
                from object element in value as IEnumerable<object>
                let propertyValue =
                    Property == null ?
                        element :
                        element.GetType().GetProperty(Property).GetValue(element)
                select propertyValue;
            return String.Join(Separator, sequence);
        }
        object IValueConverter.ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
