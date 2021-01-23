    public class JSONDateToDate : MarkupExtension,  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var jSONDate = parameter as string;
            if (!string.IsNullOrEmpty(jSONDate))
            {
                DateTime dt;
                if DateTime.TryParse(jSONDate, out dt)
                {
                    return dt;
                }
            }
            // If didn't pass in string or TryParse failed return back empty datetime
            return new DateTime();
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
