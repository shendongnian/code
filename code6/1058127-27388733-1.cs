    using System;
    using Windows.UI.Xaml.Data;
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var doubleNumber = (double)value;
            return doubleNumber.ToString("0.00#################");
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var stringValue = (string)value;
            return double.Parse(stringValue);
        }
    }
