    using System;
    using System.Windows.Data;
    
    namespace DataGridSample.Converter
    {
        public class AgeAboveLimitConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    return (int)value > 50;
                }
    
                return false;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
    }
