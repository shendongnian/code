    public class StringFormatConverter : MarkupExtension, IMultiValueConverter
    {
        [ConstructorArgument("formatString")]
        public string FormatString { get; set; }
        public StringFormatConverter() {}
        public StringFormatConverter(string formatString)
        {
            this.FormatString = formatString;
        }
        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return string.Format(culture, this.FormatString, values);
        }
        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
