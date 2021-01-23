    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace WpfApplication1
    {
        public class SplitConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (value as string).Split('|');
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return string.Join("|", value as string[]);
            }
        }
    }
