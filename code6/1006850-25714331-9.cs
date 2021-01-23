    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    
    namespace WPFPlayground
    {
        public class DefectiveToBackgroundColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (System.Convert.ToBoolean(value))
                {
                    return new SolidColorBrush(Colors.Red);
                }
                return new SolidColorBrush(Colors.White);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Binding.DoNothing;
            }
        }
    }
