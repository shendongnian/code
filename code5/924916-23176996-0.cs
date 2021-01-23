    public class JSONDateToTime : MarkupExtension,  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var jSONDate = parameter as string;
            if (!string.IsNullOrEmpty(jSONDate))
            {
                var dt = new DateTime(1970, 1, 1).AddMilliseconds(System.Convert.ToDouble(jSONDate));
                return dt.ToString("{HH:mm}");
            }
            else
            {
                // If didn't pass in string return back empty string
                return String.Empty;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        // Not needed just nice
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
